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

            using (var hc = new HttpClient()) {
                //string xml = await hc.GetStringAsync(tbUrl.Text);
                //XDocument xdoc = XDocument.Parse(xml);
                XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(tbUrl.Text)); //RSS�̎擾

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();

                //���X�g�{�b�N�X�փ^�C�g����\��
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));
                //items.ForEach(item => lbTitles.Items.Add(item.Link));
                /*foreach (var i in items) {
                    lbTitles.Items.Add(i.Title);
                }*/
            }
        }

        //�^�C�g����I�������Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
            int n = lbTitles.SelectedIndex;
            webView21.Source = new Uri(items[n].Link);
        }
    }
}