using System.Net;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string> {
            {"���X�|���n", "https://news.yahoo.co.jp/rss/media/tspkeiba/all.xml"},
            {"�n�g�N��m", "https://news.yahoo.co.jp/rss/media/umatokuh/all.xml"},
            {"���n���{", "https://news.yahoo.co.jp/rss/media/keibalab/all.xml"},
            {"���n�̂��͂Ȃ�", "https://news.yahoo.co.jp/rss/media/keibana/all.xml"},
            {"�Q�n�e���r", "https://news.yahoo.co.jp/rss/media/gtv/all.xml"},
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
            if (items is null || lbTitles.SelectedItems is null) {                return;
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

            rssUrlDict.Add(tbTitle.Text, cbUrl.Text);
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
            tsslbMessage.Text = "�o�^���܂���";

            //�{�b�N�X�̏�����
            cbUrl.SelectedIndex = -1;
            tbTitle.Clear();
        }

        //�R���{�{�b�N�X�̋L�^���폜
        private void btRecordDelete_Click(object sender, EventArgs e) {
        if (cbUrl.Text == "") {
                tsslbMessage.Text = "�^�C�g���EURL���I������Ă��܂���";
                return;
            }

            rssUrlDict.Remove(cbUrl.SelectedItem.ToString());
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
            tsslbMessage.Text = "�폜���܂���";

            //�{�b�N�X�̏�����
            cbUrl.SelectedIndex = -1;
            tbTitle.Clear();
        }
    }
}