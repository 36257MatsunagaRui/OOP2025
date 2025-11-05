using System;
using System.IO;
using System.Text;

namespace Exercise01_Form {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "ファイルを読み込み中";

            string filePath = "C://Users//infosys//source//repos//OOP2025//Chapter14//演習問題//Exercise01_Form//吾輩は猫である.txt";

            try {
                StringBuilder fileContentBuilder = new StringBuilder();

                using (StreamReader reader = new StreamReader(filePath)) {
                    string line;

                    while ((line = await reader.ReadLineAsync()) != null) {
                        fileContentBuilder.AppendLine(line);
                    }
                }

                textBox1.Text = fileContentBuilder.ToString();
                toolStripStatusLabel1.Text = "ファイルの読み込み完了";
            }
            catch (FileNotFoundException) {
                toolStripStatusLabel1.Text = "指定されたファイルが見つかりませんでした";
            }
            catch (Exception ex) {
                toolStripStatusLabel1.Text = "ファイルの読み込み中にエラーが発生しました";
            }
        }
    }
}