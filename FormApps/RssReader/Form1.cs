using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

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
                    XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(cbUrl.Text)); //RSS�̎擾

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();
                    setCbUrl(cbUrl.Text);
                }
            }
            catch (Exception) {
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

        //�^�C�g����I�������Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
            if (items is null || lbTitles.SelectedItems is null) {
                return;
            }
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
        }

        //�u���E�U�t�H���[�h
        private void btForward_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        //�u���E�U�o�b�N
        private void btBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }

        //�R���{�{�b�N�X�֓o�^(�d���Ȃ�)
        private void setCbUrl(string Link) {
            if (cbUrl.Items.Contains(Link)) {
                return;
            } else if (Link == "") {
                return;
            }

            cbUrl.Items.Add(Link);
        }

        private void wvRssLink_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e) {
            GoFowardBtEnableSet();
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            GoFowardBtEnableSet();
        }

        //�}�X�N����
        private void GoFowardBtEnableSet() {
            btForward.Enabled = wvRssLink.CanGoForward;
            btBack.Enabled = wvRssLink.CanGoBack;
        }

        private void Form1_Load(object sender, EventArgs e) {
            btForward.Enabled = wvRssLink.CanGoForward;
            btBack.Enabled = wvRssLink.CanGoBack;
        }
    }
}