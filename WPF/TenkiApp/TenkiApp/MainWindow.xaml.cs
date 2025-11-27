using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace TenkiApp {
    public class FavoriteData {
        public List<string> FavoritePrefectures { get; set; } = new List<string>();
    }

    public static class FavoriteManager {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favorites.json");

        // お気に入りをロード
        public static FavoriteData LoadFavorites() {
            if (!File.Exists(FilePath)) return new FavoriteData();
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<FavoriteData>(json) ?? new FavoriteData();
        }

        // お気に入りを保存
        public static void SaveFavorites(FavoriteData data) {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }

    public class WeeklyWeatherItem {
        public string Date { get; set; }
        public DateTime DateTimeValue { get; set; }
        public string DayOfWeek { get; set; }  // 曜日
        public string Weather { get; set; }
        public string Temp { get; set; }
        public string Wind { get; set; }

        public string WeatherIcon {
            get {
                string seasonIcon = GetSeasonIcon();
                if (Weather.Contains("晴")) return "☀️" + seasonIcon;
                if (Weather.Contains("曇")) return "☁️" + seasonIcon;
                if (Weather.Contains("雨")) return "🌧️" + seasonIcon;
                if (Weather.Contains("雪")) return "❄️" + seasonIcon;
                if (Weather.Contains("雷")) return "⚡" + seasonIcon;
                if (Weather.Contains("霧")) return "🌫️" + seasonIcon;
                return "❔" + seasonIcon;
            }
        }

        public Brush BackgroundColor {
            get {
                int month = DateTimeValue.Month;
                if (month >= 3 && month <= 5) return new SolidColorBrush(Color.FromRgb(255, 228, 225));
                if (month >= 6 && month <= 8) return new SolidColorBrush(Color.FromRgb(204, 229, 255));
                if (month >= 9 && month <= 11) return new SolidColorBrush(Color.FromRgb(255, 218, 185));
                return new SolidColorBrush(Color.FromRgb(230, 240, 255));
            }
        }

        private string GetSeasonIcon() {
            int month = DateTimeValue.Month;
            return month switch {
                3 or 4 or 5 => "🌸",
                6 or 7 or 8 => "🏖️",
                9 or 10 or 11 => "🍁",
                _ => "🧣",
            };
        }
    }

    public class DailyWeather {
        [JsonPropertyName("time")] public List<string> Time { get; set; }
        [JsonPropertyName("weathercode")] public List<int> WeatherCode { get; set; }
        [JsonPropertyName("temperature_2m_max")] public List<double> TempMax { get; set; }
        [JsonPropertyName("temperature_2m_min")] public List<double> TempMin { get; set; }
        [JsonPropertyName("windspeed_10m_max")] public List<double> WindSpeedMax { get; set; }
    }

    public class CurrentWeather {
        [JsonPropertyName("temperature")] public double Temperature { get; set; }
        [JsonPropertyName("weathercode")] public int WeatherCode { get; set; }
        [JsonPropertyName("windspeed")] public double Windspeed { get; set; }
        [JsonPropertyName("winddirection")] public double Winddirection { get; set; }
    }

    public class DailyWeatherResponse {
        [JsonPropertyName("daily")] public DailyWeather Daily { get; set; }
        [JsonPropertyName("current_weather")] public CurrentWeather CurrentWeather { get; set; }
    }

    public partial class MainWindow : Window {
        private static readonly HttpClient _httpClient = new();
        private DispatcherTimer _timer;

        private static readonly Dictionary<int, string> WmoDescriptions = new()
        {
            {0,"快晴"},{1,"晴れ (主に晴れ)"},{2,"晴れ (一部曇り)"},{3,"曇り"},
            {45,"霧"},{48,"霧氷を伴う霧"},{51,"霧雨 (弱)"},{53,"霧雨 (中)"},{55,"霧雨 (強)"},
            {61,"小雨"},{63,"雨 (中)"},{65,"大雨"},{66,"着氷性の雨 (弱)"},{67,"着氷性の雨 (強)"},
            {71,"弱い雪"},{73,"中程度の雪"},{75,"激しい雪"},{77,"雪粒"},
            {80,"にわか雨 (弱)"},{81,"にわか雨 (中)"},{82,"にわか雨 (激しい)"},
            {85,"弱い雪のにわか雨"},{86,"激しい雪のにわか雨"},{95,"雷雨 (弱〜中)"},
            {96,"雷雨 (弱いひょうを伴う)"},{99,"雷雨 (激しいひょうを伴う)"}
        };

        private static readonly Dictionary<string, (double Latitude, double Longitude)> PrefectureCoordinates = new()
        {
            {"北海道", (43.063968, 141.347899)}, {"青森県", (40.824623, 140.740593)}, {"岩手県", (39.703531, 141.152667)},
            {"宮城県", (38.268839, 140.872103)}, {"秋田県", (39.718611, 140.102388)}, {"山形県", (38.256795, 140.363402)},
            {"福島県", (37.750278, 140.467475)}, {"茨城県", (36.341829, 140.446824)}, {"栃木県", (36.565851, 139.883637)},
            {"群馬県", (36.391233, 139.060416)}, {"埼玉県", (35.856986, 139.648937)}, {"千葉県", (35.605374, 140.123337)},
            {"東京都", (35.689521, 139.691704)}, {"神奈川県", (35.447753, 139.642514)}, {"新潟県", (37.902341, 139.023253)},
            {"富山県", (36.695304, 137.211688)}, {"石川県", (36.561389, 136.656111)}, {"福井県", (36.065278, 136.221111)},
            {"山梨県", (35.663889, 138.568333)}, {"長野県", (36.651944, 138.188056)}, {"岐阜県", (35.391111, 136.722222)},
            {"静岡県", (34.976944, 138.383333)}, {"愛知県", (35.180188, 136.906565)}, {"三重県", (34.730278, 136.508611)},
            {"滋賀県", (35.004444, 135.868333)}, {"京都府", (35.011667, 135.768333)}, {"大阪府", (34.686315, 135.520000)},
            {"兵庫県", (34.691389, 135.183056)}, {"奈良県", (34.685278, 135.805556)}, {"和歌山県", (34.226389, 135.1675)},
            {"鳥取県", (35.503611, 134.238333)}, {"島根県", (35.472222, 133.050556)}, {"岡山県", (34.661667, 133.921)},
            {"広島県", (34.396564, 132.459637)}, {"山口県", (34.185833, 131.564167)}, {"徳島県", (34.075833, 134.559444)},
            {"香川県", (34.343333, 134.043333)}, {"愛媛県", (33.841667, 132.766111)}, {"高知県", (33.559722, 133.531111)},
            {"福岡県", (33.606785, 130.418314)}, {"佐賀県", (33.249444, 130.2975)}, {"長崎県", (32.783333, 129.873611)},
            {"熊本県", (32.789722, 130.741667)}, {"大分県", (33.238611, 131.612778)}, {"宮崎県", (31.911111, 131.423889)},
            {"鹿児島県", (31.560278, 130.558333)}, {"沖縄県", (26.212401, 127.680932)}
        };

        public MainWindow() {
            InitializeComponent();
            PrefectureComboBox.ItemsSource = PrefectureCoordinates.Keys;
            PrefectureComboBox.SelectedItem = "東京都";

            UpdateFavoriteListUI();

            // 現在時刻更新
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => {
                CurrentTimeLabel.Text = DateTime.Now.ToString("HH:mm");
                CurrentDateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd");
            };
            _timer.Start();
        }

        // 都道府県コンボボックスが変更されたときの処理
        private async void PrefectureComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (PrefectureComboBox.SelectedItem == null) return;
            await FetchWeather(PrefectureComboBox.SelectedItem.ToString());
        }

        // 天気情報を取得
        private async System.Threading.Tasks.Task FetchWeather(string prefecture) {
            try {
                StatusLabel.Text = "天気を取得中…";
                if (!PrefectureCoordinates.TryGetValue(prefecture, out var coords)) {
                    StatusLabel.Text = "座標が見つかりません。";
                    return;
                }

                string url = $"https://api.open-meteo.com/v1/forecast?latitude={coords.Latitude}&longitude={coords.Longitude}&current_weather=true&daily=temperature_2m_max,temperature_2m_min,windspeed_10m_max,weathercode&timezone=Asia/Tokyo";
                string json = await _httpClient.GetStringAsync(url);
                var data = JsonSerializer.Deserialize<DailyWeatherResponse>(json);

                if (data?.CurrentWeather != null) {
                    // 現在天気
                    PrefectureLabel.Text = prefecture;
                    TemperatureLabel.Text = $"{data.CurrentWeather.Temperature:F1} °C";
                    WeatherDescriptionLabel.Text = WmoDescriptions.ContainsKey(data.CurrentWeather.WeatherCode)
                        ? WmoDescriptions[data.CurrentWeather.WeatherCode]
                        : "不明";

                    WindLabel.Text = $"風速: {data.CurrentWeather.Windspeed:F1} m/s / 風向: {data.CurrentWeather.Winddirection:F0}°";

                    CurrentWeatherIcon.Text = WeatherDescriptionLabel.Text.Contains("晴") ? "☀️"
                                            : WeatherDescriptionLabel.Text.Contains("曇") ? "☁️"
                                            : WeatherDescriptionLabel.Text.Contains("雨") ? "🌧️"
                                            : WeatherDescriptionLabel.Text.Contains("雪") ? "❄️"
                                            : "❔";

                    WeatherTipLabel.Text = WeatherDescriptionLabel.Text.Contains("雨") ? "傘を忘れずに！" : "快適な天気です。";

                    // 週間天気
                    var weekly = new List<WeeklyWeatherItem>();
                    for (int i = 0; i < data.Daily.Time.Count; i++) {
                        var dateTime = DateTime.Parse(data.Daily.Time[i]);
                        weekly.Add(new WeeklyWeatherItem {
                            DateTimeValue = dateTime,
                            Date = dateTime.ToString("MM/dd"),
                            DayOfWeek = dateTime.ToString("dddd", new CultureInfo("ja-JP")),  // 曜日を取得
                            Weather = WmoDescriptions.ContainsKey(data.Daily.WeatherCode[i]) ? WmoDescriptions[data.Daily.WeatherCode[i]] : "不明",
                            Temp = $"最高: {data.Daily.TempMax[i]:F1}°C / 最低: {data.Daily.TempMin[i]:F1}°C",
                            Wind = $"風速: {data.Daily.WindSpeedMax[i]:F1} m/s"
                        });
                    }
                    WeeklyWeatherPanel.ItemsSource = weekly;

                    StatusLabel.Text = "天気取得完了。";
                }
            }
            catch {
                StatusLabel.Text = "天気取得に失敗しました。";
            }
        }

        // お気に入りリストの更新
        private void UpdateFavoriteListUI() {
            var favData = FavoriteManager.LoadFavorites();
            FavoriteComboBox.ItemsSource = null;
            FavoriteComboBox.ItemsSource = favData.FavoritePrefectures;
        }

        // お気に入り登録トグルボタンのクリック処理
        private void ToggleFavoriteButton_Click(object sender, RoutedEventArgs e) {
            if (PrefectureComboBox.SelectedItem == null) return;
            string prefecture = PrefectureComboBox.SelectedItem.ToString();
            var favData = FavoriteManager.LoadFavorites();
            if (favData.FavoritePrefectures.Contains(prefecture)) {
                favData.FavoritePrefectures.Remove(prefecture);
                StatusLabel.Text = $"{prefecture} をお気に入りから削除しました。";
            } else {
                favData.FavoritePrefectures.Add(prefecture);
                StatusLabel.Text = $"{prefecture} をお気に入りに追加しました。";
            }
            FavoriteManager.SaveFavorites(favData);
            UpdateFavoriteListUI();
        }

        // お気に入り表示ボタンのクリック処理
        private async void ShowFavoriteButton_Click(object sender, RoutedEventArgs e) {
            if (FavoriteComboBox.SelectedItem == null) return;
            string favoritePrefecture = FavoriteComboBox.SelectedItem.ToString();
            PrefectureComboBox.SelectedItem = favoritePrefecture;
            await FetchWeather(favoritePrefecture);
        }
    }
}
