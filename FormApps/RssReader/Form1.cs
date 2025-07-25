using System.Net;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string> {
            {"東スポ競馬", "https://news.yahoo.co.jp/rss/media/tspkeiba/all.xml"},
            {"馬トク報知", "https://news.yahoo.co.jp/rss/media/umatokuh/all.xml"},
            {"競馬ラボ", "https://news.yahoo.co.jp/rss/media/keibalab/all.xml"},
            {"競馬のおはなし", "https://news.yahoo.co.jp/rss/media/keibana/all.xml"},
            {"群馬テレビ", "https://news.yahoo.co.jp/rss/media/gtv/all.xml"},
        };


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
                    XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(GetRssUrl(cbUrl.Text))); //RSSの取得

                    //RSSを解析して必要な要素を取得
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();
                }
            }
            catch (Exception) {
                tsslbMessage.Text = "タイトル・URLが選択されていません";
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

        //コンボボックスの文字列をチェックしてアクセス可能なURLを返す
        private string GetRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            }
            return str;
        }

        //タイトルを選択したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            if (items is null || lbTitles.SelectedItems is null) {                return;
            }
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
        }

        //ブラウザフォワード
        private void btGoForward_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        //ブラウザバック
        private void btGoBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }

        //コンボボックスへ登録(重複なし)
        /*private void setCbUrl(string Link) {
            if (cbUrl.Items.Contains(Link)) {
                return;
            } else if (Link == "") {
                return;
            }
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
        }*/

        private void wvRssLink_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e) {
            //このプログラムには適さない
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            GoFowardBtEnableSet();
        }

        //マスク処理
        private void GoFowardBtEnableSet() {
            btGoForward.Enabled = wvRssLink.CanGoForward;
            btGoBack.Enabled = wvRssLink.CanGoBack;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //マスク処理
            GoFowardBtEnableSet();

            //コンボボックスへ登録
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();

            //起動時、コンボボックスを空欄にする
            cbUrl.SelectedIndex = -1;

            tsslbMessage.Text = "ようこそ！";
        }

        //コンボボックスへ登録
        private void btRecordAdd_Click(object sender, EventArgs e) {
            //重複なし
            if (rssUrlDict.ContainsValue(cbUrl.Text) || rssUrlDict.ContainsKey(tbTitle.Text)) {
                tsslbMessage.Text = "登録済みです";
                return;
            } else if (tbTitle.Text == "") {
                tsslbMessage.Text = "タイトルを入力してください";
                return;
            } else if (cbUrl.Text == "") {
                tsslbMessage.Text = "URLを入力してください";
                return;
            }

            rssUrlDict.Add(tbTitle.Text, cbUrl.Text);
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
            tsslbMessage.Text = "登録しました";

            //ボックスの初期化
            cbUrl.SelectedIndex = -1;
            tbTitle.Clear();
        }

        //コンボボックスの記録を削除
        private void btRecordDelete_Click(object sender, EventArgs e) {
        if (cbUrl.Text == "") {
                tsslbMessage.Text = "タイトル・URLが選択されていません";
                return;
            }

            rssUrlDict.Remove(cbUrl.SelectedItem.ToString());
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
            tsslbMessage.Text = "削除しました";

            //ボックスの初期化
            cbUrl.SelectedIndex = -1;
            tbTitle.Clear();
        }
    }
}