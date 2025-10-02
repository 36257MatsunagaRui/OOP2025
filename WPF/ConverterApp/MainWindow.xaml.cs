using System.Collections.Generic;
using System.Windows;
using System;

namespace ConverterApp {
    public partial class MainWindow : Window {
        private const string METERS = "m";
        private const string FEET = "ft";
        private const string CENTIMETERS = "cm";
        private const string INCHES = "in";
        private const string KILOMETERS = "km";
        private const string MILLIMETERS = "mm";
        private const string YARDS = "yd";
        private const string MILES = "mi";

        //ComboBoxに表示する単位のリスト
        public List<string> UnitNames { get; set; } = new List<string> { METERS, FEET, CENTIMETERS, INCHES, KILOMETERS, MILLIMETERS, YARDS, MILES};

        //基準単位への変換係数を格納するDictionary
        //Key:単位名, Value:その単位からmに変換するための乗数
        private Dictionary<string, double> ToMeterFactors = new Dictionary<string, double>
        {
            { METERS, 1.0 },         //1m = 1m
            { FEET, 0.3048 },        //1ft = 0.3048m
            { CENTIMETERS, 0.01 },   //1cm = 0.01m
            { INCHES, 0.0254 },      //1in = 0.0254m
            { KILOMETERS, 1000.0 },  //1km = 1000m
            { MILLIMETERS, 0.001 },  //1mm = 0.001m
            { YARDS, 0.9144 },       //1yd = 0.9144m
            { MILES, 1609.344 }      //1mi = 1609.344m
        };

        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        private void MetricToImperialUnit_Click(object sender, RoutedEventArgs e) {
            if (double.TryParse(MetricValue.Text, out double metricValue)) {
                string metricUnit = MetricUnit.SelectedItem as string;
                string imperialUnit = ImperialUnit.SelectedItem as string;

                //選択されている単位が有効か確認
                if (metricUnit == null || imperialUnit == null ||
                    !ToMeterFactors.ContainsKey(metricUnit) || !ToMeterFactors.ContainsKey(imperialUnit)) {
                    ImperialValue.Text = "単位エラー";
                    return;
                }

                try {
                    //metricValueを基準単位のメートルに変換
                    double valueInMeters = metricValue * ToMeterFactors[metricUnit];

                    //メートルからimperialUnitに変換
                    //目的単位の係数で割る
                    double imperial = valueInMeters / ToMeterFactors[imperialUnit];

                    ImperialValue.Text = imperial.ToString("F4");
                }
                catch {
                    ImperialValue.Text = "計算エラー";
                }
            } else {
                ImperialValue.Text = "入力エラー";
            }
        }

        private void ImperialUnitToMetric_Click(object sender, RoutedEventArgs e) {
            if (double.TryParse(ImperialValue.Text, out double imperialValue)) {
                string metricUnit = MetricUnit.SelectedItem as string;
                string imperialUnit = ImperialUnit.SelectedItem as string;

                //選択されている単位が有効か確認
                if (metricUnit == null || imperialUnit == null ||
                    !ToMeterFactors.ContainsKey(metricUnit) || !ToMeterFactors.ContainsKey(imperialUnit)) {
                    MetricValue.Text = "単位エラー";
                    return;
                }

                try {
                    //imperialValueを基準単位のメートルに変換
                    double valueInMeters = imperialValue * ToMeterFactors[imperialUnit];

                    //メートルからmetricUnitに変換
                    double metric = valueInMeters / ToMeterFactors[metricUnit];

                    MetricValue.Text = metric.ToString("F4");
                }
                catch {
                    MetricValue.Text = "計算エラー";
                }
            } else {
                MetricValue.Text = "入力エラー";
            }
        }
    }
}