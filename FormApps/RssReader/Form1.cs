using System;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Settings settings = Settings.getInstance();

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string> {
            {"���X�|���n", "https://news.yahoo.co.jp/rss/media/tspkeiba/all.xml"},
            {"�n�g�N��m", "https://news.yahoo.co.jp/rss/media/umatokuh/all.xml"},
            {"���n���{", "https://news.yahoo.co.jp/rss/media/keibalab/all.xml"},
            {"���n�̂��͂Ȃ�", "https://news.yahoo.co.jp/rss/media/keibana/all.xml"},
            {"�Q�n�e���r", "https://news.yahoo.co.jp/rss/media/gtv/all.xml"},
            {"�T���P�C�X�|�[�c", "https://news.yahoo.co.jp/rss/media/sanspo/all.xml"},
            {"SPAIA AI���n", "https://news.yahoo.co.jp/rss/media/spaia/all.xml"},
        };


        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            /*using (var wc = new WebClient()) {
                //�񐄏��̃R�[�h
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url); //RSS�̎擾*/
            try {
                using (var hc = new HttpClient()) {
                    //string xml = await hc.GetStringAsync(tbUrl.Text);
                    //XDocument xdoc = XDocument.Parse(xml);

                    XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(GetRssUrl(cbUrl.Text))); //RSS�̎擾

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();
                    tsslbMessage.Text = "";
                }
            }
            catch (Exception) {
                tsslbMessage.Text = "�^�C�g���EURL���I������Ă��܂���";
                return;
            }

            //���X�g�{�b�N�X�փ^�C�g����\��
            lbTitles.Items.Clear();
            items.ForEach(item => lbTitles.Items.Add(item.Title));
            //items.ForEach(item => lbTitles.Items.Add(item.Link));
            /*foreach (var i in items) {
                lbTitles.Items.Add(i.Title);
            }*/
        }

        //�R���{�{�b�N�X�̕�������`�F�b�N���ăA�N�Z�X�\��URL��Ԃ�
        private string GetRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            }
            return str;
        }

        //�^�C�g����I�������Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
            if (items is null || lbTitles.SelectedItems is null) {
                return;
            }
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
        }

        //�u���E�U�t�H���[�h
        private void btGoForward_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        //�u���E�U�o�b�N
        private void btGoBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }

        //�R���{�{�b�N�X�֓o�^(�d���Ȃ�)
        /*private void setCbUrl(string Link) {
            if (cbUrl.Items.Contains(Link)) {
                return;
            } else if (Link == "") {
                return;
            }
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
        }*/

        private void wvRssLink_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e) {
            //���̃v���O�����ɂ͓K���Ȃ�
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            GoFowardBtEnableSet();
        }

        //�}�X�N����
        private void GoFowardBtEnableSet() {
            btGoForward.Enabled = wvRssLink.CanGoForward;
            btGoBack.Enabled = wvRssLink.CanGoBack;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //�}�X�N����
            GoFowardBtEnableSet();

            //�R���{�{�b�N�X�֓o�^
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();

            //�N�����A�R���{�{�b�N�X���󗓂ɂ���
            cbUrl.SelectedIndex = -1;

            tsslbMessage.Text = "�悤�����I";
        }

        //�R���{�{�b�N�X�֓o�^
        private void btRecordAdd_Click(object sender, EventArgs e) {
            //�d���Ȃ�
            if (rssUrlDict.ContainsValue(cbUrl.Text) || rssUrlDict.ContainsKey(tbTitle.Text)) {
                tsslbMessage.Text = "�o�^�ς݂ł�";
                return;
            } else if (tbTitle.Text == "") {
                tsslbMessage.Text = "�^�C�g������͂��Ă�������";
                return;
            } else if (cbUrl.Text == "") {
                tsslbMessage.Text = "URL����͂��Ă�������";
                return;
            }

            //���͂��ꂽURL���L�������ʂ���
            string title = tbTitle.Text.Trim(); //�^�C�g�����擾���A�O��̋󔒂��g����
            string url = cbUrl.Text.Trim();     //URL���擾���A�O��̋󔒂��g����
            Uri uriResult;
            bool isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                              (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!isValidUrl) {
                tsslbMessage.Text = "���͂��ꂽURL�͗L���Ȍ`���ł͂���܂���";
                return;
            }

            //�R���{�{�b�N�X�֓o�^
            rssUrlDict.Add(tbTitle.Text, cbUrl.Text);
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
            tsslbMessage.Text = "�o�^���܂���";

            //�{�b�N�X�̏�����
            cbUrl.SelectedIndex = -1;
            tbTitle.Clear();
        }

        //�R���{�{�b�N�X�̋L�^���폜
        private void btRecordDelete_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem is null) {
                tsslbMessage.Text = "�폜���邨�C�ɓ����I�����Ă�������";
                return;
            }

            if (rssUrlDict.ContainsKey(cbUrl.SelectedItem.ToString())) {
                rssUrlDict.Remove(cbUrl.SelectedItem.ToString());
                cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
                tsslbMessage.Text = "�폜���܂���";
            } else {
                tsslbMessage.Text = "�I�����ꂽ���C�ɓ���͌�����܂���ł���";
            }

            //�{�b�N�X�̏�����
            cbUrl.SelectedIndex = -1;
            tbTitle.Clear();
        }

        //ListBox�̊e�A�C�e����`�悷��C�x���g�n���h��(�����s�ɐF��t����)
        private void lbTitles_DrawItem(object sender, DrawItemEventArgs e) {
            //�`�悷��ListBox�C���X�^���X���擾
            ListBox lb = (ListBox)sender;

            //�A�C�e�����Ȃ��ꍇ��A�����ȃC���f�b�N�X�̏ꍇ�͕`�悵�Ȃ�
            if (e.Index < 0 || e.Index >= lb.Items.Count) {
                return;
            }

            //�`�悷��A�C�e���̃e�L�X�g���擾
            string itemText = lb.Items[e.Index].ToString();

            //�`�悷��w�i�F�ƑO�i�F������
            Color backgroundColor;
            Color textColor;

            //�����s
            if (e.Index % 2 == 1) {
                backgroundColor = Color.LightBlue; // �����s�̔w�i�F
                textColor = Color.Black; // �����s�̃e�L�X�g�F
            } else {
                //��s
                backgroundColor = Color.White; // ��s�̔w�i�F
                textColor = Color.Black; // ��s�̃e�L�X�g�F
            }

            //�I������Ă���A�C�e���̏ꍇ�A�I��F��D��
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                backgroundColor = SystemColors.Highlight; //�I�����ꂽ�A�C�e���̔w�i�F
                textColor = SystemColors.HighlightText; //�I�����ꂽ�A�C�e���̃e�L�X�g�F
            }

            //�w�i��`��
            using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor)) {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            //�e�L�X�g��`��
            using (SolidBrush textBrush = new SolidBrush(textColor)) {
                //�e�L�X�g�̕`��ʒu�Ə�����ݒ�
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center; //����������������
                sf.Trimming = StringTrimming.EllipsisCharacter;

                //e.Bounds �̓A�C�e���S�̗̂̈�
                //e.Font �̓f�t�H���g�̃t�H���g
                e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds, sf);
            }

            // �t�H�[�J�X������ꍇ�A�t�H�[�J�X�l�p�`��`��
            e.DrawFocusRectangle();


            /*���X�g�{�b�N�X�̌��ݐF�ύX
            var idx = e.Index;                                                      //�`��Ώۂ̍s
            if (idx == -1) return;                                                  //�͈͊O�Ȃ牽�����Ȃ�
            var sts = e.State;                                                      //�Z���̏��
            var fnt = e.Font;                                                       //�t�H���g
            var _bnd = e.Bounds;                                                    //�`��͈�(�I���W�i��)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);     //�`��͈�(�`��p)
            var txt = (string)lbTitles.Items[idx];                                  //���X�g�{�b�N�X���̕���
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //�����F
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //�I���s��
            var odd = (idx % 2 == 1);                                               //��s��
            var fore = Brushes.WhiteSmoke;                                         //�����s�̔w�i�F
            var bak = Brushes.AliceBlue;                                           //��s�̔w�i�F

            e.DrawBackground();                                                     //�w�i�`��

            //����ڂ̔w�i�F��ς���i�I���s�͏����j
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //������`��
            e.Graphics.DrawString(txt, fnt, bsh, bnd);*/
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e) {
            //�_�C�A���O��\�����A���[�U�[��OK���N���b�N������F���擾
            if (cdColor.ShowDialog() == DialogResult.OK) {
                //�I�����ꂽ�F���t�H�[���̔w�i�F�ɐݒ肷��
                BackColor = cdColor.Color;
                //�ݒ�t�@�C���֕ۑ�
                settings.MainFormBackColor = cdColor.Color.ToArgb(); //�w�i�F��ݒ�C���X�^���X�֐ݒ�
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}