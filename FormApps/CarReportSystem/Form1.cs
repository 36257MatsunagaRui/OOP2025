using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }

        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btRecordAdd_Click(object sender, EventArgs e) {
            tsslbMessage.Text = string.Empty;
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "記録者または、車名が未入力です";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text,
                Maker = getRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);
            setCbAuthor(cbAuthor.Text); //コンボボックスへ登録(記録者)
            setCbCarName(cbCarName.Text); //コンボボックスへ登録(車名)
            InputItemsAllClear(); //登録後は項目をクリア
        }

        //入力項目をすべてクリア
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        private CarReport.MakerGroup getRadioButtonMaker() {
            if (rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
            } else if (rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            } else if (rbImport.Checked) {
                return CarReport.MakerGroup.輸入車;
            } else {
                return CarReport.MakerGroup.その他;
            }
        }

        private void dgvRecord_Click(object sender, EventArgs e) {
            if (dgvRecord.CurrentRow is null) {
                return;
            } else {
                dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
                cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
                setRadioButtonMaker((CarReport.MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
                cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
                tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
                pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
            }
        }

        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        //記録者の履歴をコンボボックスへ登録(重複なし)
        private void setCbAuthor(string author) {
            //既に登録済みか確認
            if (cbAuthor.Items.Contains(author)) {
                return;
            } else if (author == "") {
                return;
            }

            /*if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }*/

            //未登録なら登録(登録済みなら何もしない)
            cbAuthor.Items.Add(author);
        }

        //車名の履歴をコンボボックスへ登録(重複なし)
        private void setCbCarName(string carName) {
            if (cbCarName.Items.Contains(carName)) {
                return;
            } else if (carName == "") {
                return;
            }

            /*if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }*/
        }

        //新規追加のイベントハンドラ
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //修正ボタンのイベントハンドラ
        private void btRecordModify_Click(object sender, EventArgs e) {
            //選択されてない場合は処理を行わない
            if ((dgvRecord.CurrentRow is null) || (!dgvRecord.CurrentRow.Selected)) {
                //if (dgvRecord.Rows.Count == 0) return;
                return;
            } else {
                //選択されているインデックスを取得
                int index = dgvRecord.CurrentRow.Index;
                listCarReports[index].Date = dtpDate.Value.Date;
                listCarReports[index].Author = cbAuthor.Text;
                listCarReports[index].Maker = getRadioButtonMaker();
                listCarReports[index].CarName = cbCarName.Text;
                listCarReports[index].Report = tbReport.Text;
                listCarReports[index].Picture = pbPicture.Image;
            }
            dgvRecord.Refresh(); //データグリッドビューの更新
        }

        //削除ボタンのイベントハンドラ
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //選択されてない場合は処理を行わない
            if ((dgvRecord.CurrentRow is null) || (!dgvRecord.CurrentRow.Selected)) {
                return;
            } else {
                //選択されているインデックスを取得
                int index = dgvRecord.CurrentRow.Index;
                //カーレポート管理リストから該当するデータを削除する
                listCarReports.RemoveAt(index);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();
            //交互に色を設定
            dgvRecord.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue;
        }

        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
            //Close();
        }

        //「このアプリについて」を選択したときのイベントハンドラ
        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            //ダイアログを表示し、ユーザーがOKをクリックしたら色を取得
            if (cdColor.ShowDialog() == DialogResult.OK) {
                //選択された色をフォームの背景色に設定する
                this.BackColor = cdColor.Color;
            }
        }

        //ファイルオープン処理
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 //型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 //型またはメンバーが旧型式です

                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();

                        //コンボボックスに登録
                        foreach (var data in listCarReports) {
                            setCbAuthor(data.Author);
                            setCbCarName(data.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル形式が違います";
                }
            }
        }

        //ファイルセーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message); //より具体的なエラーを出力
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile(); //ファイルセーブ処理
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }
    }
}
