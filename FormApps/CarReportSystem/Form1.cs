using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�ݒ�N���X�̃C���X�^���X�𐶐�
        //Settings settings = new Settings();
        Settings settings = Settings.getInstance();

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
                tsslbMessage.Text = "�L�^�҂܂��́A�Ԗ��������͂ł�";
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
            setCbAuthor(cbAuthor.Text); //�R���{�{�b�N�X�֓o�^(�L�^��)
            setCbCarName(cbCarName.Text); //�R���{�{�b�N�X�֓o�^(�Ԗ�)
            InputItemsAllClear(); //�o�^��͍��ڂ��N���A
        }

        //���͍��ڂ����ׂăN���A
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
                return CarReport.MakerGroup.�g���^;
            } else if (rbNissan.Checked) {
                return CarReport.MakerGroup.���Y;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.�z���_;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.�X�o��;
            } else if (rbImport.Checked) {
                return CarReport.MakerGroup.�A����;
            } else {
                return CarReport.MakerGroup.���̑�;
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

        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^(�d���Ȃ�)
        private void setCbAuthor(string author) {
            //���ɓo�^�ς݂��m�F
            if (cbAuthor.Items.Contains(author)) {
                return;
            } else if (author == "") {
                return;
            }

            /*if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }*/

            //���o�^�Ȃ�o�^(�o�^�ς݂Ȃ牽�����Ȃ�)
            cbAuthor.Items.Add(author);
        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^(�d���Ȃ�)
        private void setCbCarName(string carName) {
            if (cbCarName.Items.Contains(carName)) {
                return;
            } else if (carName == "") {
                return;
            }

            /*if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }*/

            cbCarName.Items.Add(carName);
        }

        //�V�K�ǉ��̃C�x���g�n���h��
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //�C���{�^���̃C�x���g�n���h��
        private void btRecordModify_Click(object sender, EventArgs e) {
            //�I������ĂȂ��ꍇ�͏������s��Ȃ�
            if ((dgvRecord.CurrentRow is null) || (!dgvRecord.CurrentRow.Selected)) {
                //if (dgvRecord.Rows.Count == 0) return;
                return;
            } else {
                //�I������Ă���C���f�b�N�X���擾
                int index = dgvRecord.CurrentRow.Index;
                listCarReports[index].Date = dtpDate.Value.Date;
                listCarReports[index].Author = cbAuthor.Text;
                listCarReports[index].Maker = getRadioButtonMaker();
                listCarReports[index].CarName = cbCarName.Text;
                listCarReports[index].Report = tbReport.Text;
                listCarReports[index].Picture = pbPicture.Image;
            }
            dgvRecord.Refresh(); //�f�[�^�O���b�h�r���[�̍X�V
        }

        //�폜�{�^���̃C�x���g�n���h��
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //�I������ĂȂ��ꍇ�͏������s��Ȃ�
            if ((dgvRecord.CurrentRow is null) || (!dgvRecord.CurrentRow.Selected)) {
                return;
            } else {
                //�I������Ă���C���f�b�N�X���擾
                int index = dgvRecord.CurrentRow.Index;
                //�J�[���|�[�g�Ǘ����X�g����Y������f�[�^���폜����
                listCarReports.RemoveAt(index);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();
            //���݂ɐF��ݒ�
            dgvRecord.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue;

            //�ݒ�t�@�C����ǂݍ��ݔw�i�F��ݒ肷��(�t�V���A����)
            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var color = serializer.Deserialize(reader) as Settings;
                        //settings = serializer.Deserialize(reader) as Settings;
                        //�w�i�F�ݒ�
                        BackColor = Color.FromArgb(color?.MainFormBackColor ?? 0);
                        //�ݒ�N���X�̃C���X�^���X�ɂ����݂̐ݒ�F��ݒ�
                        settings.MainFormBackColor = BackColor.ToArgb();
                        
                        //settings = color ?? new Settings();
                        //this.BackColor = Color.FromArgb(settings.MainFormBackColor);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�ݒ�t�@�C���ǂݍ��݃G���[";
                    MessageBox.Show(ex.Message); //����̓I�ȃG���[���o��
                }
            } else {
                tsslbMessage.Text = "�ݒ�t�@�C��������܂���";
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
            //Close();
        }

        //�u���̃A�v���ɂ��āv��I�������Ƃ��̃C�x���g�n���h��
        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();
        }

        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            //�_�C�A���O��\�����A���[�U�[��OK���N���b�N������F���擾
            if (cdColor.ShowDialog() == DialogResult.OK) {
                //�I�����ꂽ�F���t�H�[���̔w�i�F�ɐݒ肷��
                BackColor = cdColor.Color;
                //�ݒ�t�@�C���֕ۑ�
                settings.MainFormBackColor = cdColor.Color.ToArgb(); //�w�i�F��ݒ�C���X�^���X�֐ݒ�
            }
        }

        //�t�@�C���I�[�v������
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011 //�^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 //�^�܂��̓����o�[�����^���ł�

                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();

                        //�R���{�{�b�N�X�ɓo�^
                        foreach (var data in listCarReports) {
                            setCbAuthor(data.Author);
                            setCbCarName(data.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                }
            }
        }

        //�t�@�C���Z�[�u����
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                    MessageBox.Show(ex.Message); //����̓I�ȃG���[���o��
                }
            }
        }

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile(); //�t�@�C���Z�[�u����
        }

        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        //�t�H�[����������Ă΂��
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            try {
                //�ݒ�t�@�C���֐F����ۑ����鏈��(�V���A����)
                //�t�@�C����:setting.xml
                using (var writer = XmlWriter.Create("setting.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "�ݒ�t�@�C�������o���G���[";
                MessageBox.Show(ex.Message); //����̓I�ȃG���[���o��
            }
        }
    }
}
