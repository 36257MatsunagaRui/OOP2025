using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker {
    public partial class MainWindow : Window {
        private ObservableCollection<MyColor> colors = new ObservableCollection<MyColor>();
        MyColor currentColor = new MyColor { Color = Color.FromRgb(0, 0, 0), Name = "Black" };

        public MainWindow() {
            InitializeComponent();
            colorListBox.ItemsSource = colors;
            DataContext = GetColorList();
        }

        //すべてのスライダーから呼ばれるイベントハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor = new MyColor {
                Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value),
                Name = ((MyColor[])DataContext).Where(c => c.Color.R == (byte)rSlider.Value &&
                                                           c.Color.G == (byte)gSlider.Value &&
                                                           c.Color.B == (byte)bSlider.Value).Select(x => x.Name).FirstOrDefault(),
            };

            colorArea.Background = new SolidColorBrush(currentColor.Color);

            //R, G, Bが全て255の場合、Whiteと見なす
            /*if (currentColor.Name == "Transparent") {
                currentColor = new MyColor{Color = Color.FromRgb(255, 255, 255), Name ="White"};
            }*/
            if (rSlider.Value == 255 && gSlider.Value == 255 && bSlider.Value == 255) {
                currentColor.Name = "White";
            }

            if (currentColor.Name == null) {
                colorComboBox.SelectedIndex = -1;
            } else {
                colorComboBox.SelectedItem = currentColor;
            }
        }

        //各スライダーの値を設定する
        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        //登録ボタン
        private void StockButton_Click(object sender, RoutedEventArgs e) {
            var newColor = new MyColor {
                Color = currentColor.Color,
                Name = currentColor.Name,
            };

            if (!colors.Contains(newColor)) {
                colors.Add(newColor);
                statusLabel.Content = "登録しました";
            } else {
                statusLabel.Content = "すでに登録済みです";
            }
        }

        public MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        //コンボボックスから色を選択
        private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (((ComboBox)sender).SelectedItem != null) {
                var comboMyColor = (MyColor)((ComboBox)sender).SelectedItem;
                setSliderValue(comboMyColor.Color);
            }
        }

        private void colorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorListBox.SelectedItem != null) {
                var ListMyColor = (MyColor)((ListBox)sender).SelectedItem;
                setSliderValue(ListMyColor.Color);
            }
        }

        //削除ボタン
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            if (colorListBox.SelectedItem != null) {
                colors.Remove((MyColor)colorListBox.SelectedItem);
                statusLabel.Content = "削除しました";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            colorComboBox.SelectedIndex = 7;
        }

        //ランダムな色を生成
        private Color GetRandomColor() {
            Random random = new Random();
            byte r = (byte)random.Next(256);
            byte g = (byte)random.Next(256);
            byte b = (byte)random.Next(256);
            return Color.FromRgb(r, g, b);
        }

        //ランダムボタン
        private void RandomButton_Click(object sender, RoutedEventArgs e) {
            Color randomColor = GetRandomColor();
            setSliderValue(randomColor);
            statusLabel.Content = "ランダムな色を生成しました";
        }
    }
}