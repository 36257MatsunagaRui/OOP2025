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
            {"東スポ競馬", "https://news.yahoo.co.jp/rss/media/tspkeiba/all.xml"},
            {"馬トク報知", "https://news.yahoo.co.jp/rss/media/umatokuh/all.xml"},
            {"競馬ラボ", "https://news.yahoo.co.jp/rss/media/keibalab/all.xml"},
            {"競馬のおはなし", "https://news.yahoo.co.jp/rss/media/keibana/all.xml"},
            {"群馬テレビ", "https://news.yahoo.co.jp/rss/media/gtv/all.xml"},
            {"サンケイスポーツ", "https://news.yahoo.co.jp/rss/media/sanspo/all.xml"},
            {"SPAIA AI競馬", "https://news.yahoo.co.jp/rss/media/spaia/all.xml"},
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
                    tsslbMessage.Text = "";
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
            if (items is null || lbTitles.SelectedItems is null) {
                return;
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

            //入力されたURLが有効か判別する
            string title = tbTitle.Text.Trim(); //タイトルを取得し、前後の空白をトリム
            string url = cbUrl.Text.Trim();     //URLを取得し、前後の空白をトリム
            Uri uriResult;
            bool isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                              (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!isValidUrl) {
                tsslbMessage.Text = "入力されたURLは有効な形式ではありません";
                return;
            }

            //コンボボックスへ登録
            rssUrlDict.Add(tbTitle.Text, cbUrl.Text);
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
            tsslbMessage.Text = "登録しました";

            //ボックスの初期化
            cbUrl.SelectedIndex = -1;
            tbTitle.Clear();
        }

        //コンボボックスの記録を削除
        private void btRecordDelete_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem is null) {
                tsslbMessage.Text = "削除するお気に入りを選択してください";
                return;
            }

            if (rssUrlDict.ContainsKey(cbUrl.SelectedItem.ToString())) {
                rssUrlDict.Remove(cbUrl.SelectedItem.ToString());
                cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
                tsslbMessage.Text = "削除しました";
            } else {
                tsslbMessage.Text = "選択されたお気に入りは見つかりませんでした";
            }

            //ボックスの初期化
            cbUrl.SelectedIndex = -1;
            tbTitle.Clear();
        }

        //ListBoxの各アイテムを描画するイベントハンドラ(偶数行に色を付ける)
        private void lbTitles_DrawItem(object sender, DrawItemEventArgs e) {
            //描画するListBoxインスタンスを取得
            ListBox lb = (ListBox)sender;

            //アイテムがない場合や、無効なインデックスの場合は描画しない
            if (e.Index < 0 || e.Index >= lb.Items.Count) {
                return;
            }

            //描画するアイテムのテキストを取得
            string itemText = lb.Items[e.Index].ToString();

            //描画する背景色と前景色を決定
            Color backgroundColor;
            Color textColor;

            //偶数行
            if (e.Index % 2 == 1) {
                backgroundColor = Color.LightBlue; // 偶数行の背景色
                textColor = Color.Black; // 偶数行のテキスト色
            } else {
                //奇数行
                backgroundColor = Color.White; // 奇数行の背景色
                textColor = Color.Black; // 奇数行のテキスト色
            }

            //選択されているアイテムの場合、選択色を優先
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                backgroundColor = SystemColors.Highlight; //選択されたアイテムの背景色
                textColor = SystemColors.HighlightText; //選択されたアイテムのテキスト色
            }

            //背景を描画
            using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor)) {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            //テキストを描画
            using (SolidBrush textBrush = new SolidBrush(textColor)) {
                //テキストの描画位置と書式を設定
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center; //垂直方向中央揃え
                sf.Trimming = StringTrimming.EllipsisCharacter;

                //e.Bounds はアイテム全体の領域
                //e.Font はデフォルトのフォント
                e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds, sf);
            }

            // フォーカスがある場合、フォーカス四角形を描画
            e.DrawFocusRectangle();


            /*リストボックスの交互色変更
            var idx = e.Index;                                                      //描画対象の行
            if (idx == -1) return;                                                  //範囲外なら何もしない
            var sts = e.State;                                                      //セルの状態
            var fnt = e.Font;                                                       //フォント
            var _bnd = e.Bounds;                                                    //描画範囲(オリジナル)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);     //描画範囲(描画用)
            var txt = (string)lbTitles.Items[idx];                                  //リストボックス内の文字
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //文字色
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //選択行か
            var odd = (idx % 2 == 1);                                               //奇数行か
            var fore = Brushes.WhiteSmoke;                                         //偶数行の背景色
            var bak = Brushes.AliceBlue;                                           //奇数行の背景色

            e.DrawBackground();                                                     //背景描画

            //奇数項目の背景色を変える（選択行は除く）
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //文字を描画
            e.Graphics.DrawString(txt, fnt, bsh, bnd);*/
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e) {
            //ダイアログを表示し、ユーザーがOKをクリックしたら色を取得
            if (cdColor.ShowDialog() == DialogResult.OK) {
                //選択された色をフォームの背景色に設定する
                BackColor = cdColor.Color;
                //設定ファイルへ保存
                settings.MainFormBackColor = cdColor.Color.ToArgb(); //背景色を設定インスタンスへ設定
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}