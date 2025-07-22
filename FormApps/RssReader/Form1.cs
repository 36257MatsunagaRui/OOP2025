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
                //非推奨のコード
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url); //RSSの取得*/
            try {
                using (var hc = new HttpClient()) {
                    //string xml = await hc.GetStringAsync(tbUrl.Text);
                    //XDocument xdoc = XDocument.Parse(xml);
                    XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(cbUrl.Text)); //RSSの取得

                    //RSSを解析して必要な要素を取得
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

            //リストボックスへタイトルを表示
            lbTitles.Items.Clear();
            items.ForEach(item => lbTitles.Items.Add(item.Title));
            //items.ForEach(item => lbTitles.Items.Add(item.Link));
            /*foreach (var i in items) {
                lbTitles.Items.Add(i.Title);
            }*/
        }

        //タイトルを選択したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            if (items is null || lbTitles.SelectedItems is null) {
                return;
            }
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
        }

        //ブラウザフォワード
        private void btForward_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        //ブラウザバック
        private void btBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }

        //コンボボックスへ登録(重複なし)
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

        //マスク処理
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