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

            using (var hc = new HttpClient()) {
                //string xml = await hc.GetStringAsync(tbUrl.Text);
                //XDocument xdoc = XDocument.Parse(xml);
                XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(tbUrl.Text)); //RSSの取得

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();

                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));
                //items.ForEach(item => lbTitles.Items.Add(item.Link));
                /*foreach (var i in items) {
                    lbTitles.Items.Add(i.Title);
                }*/
            }
        }

        //タイトルを選択したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            int n = lbTitles.SelectedIndex;
            webView21.Source = new Uri(items[n].Link);
        }
    }
}