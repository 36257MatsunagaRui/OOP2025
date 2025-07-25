namespace RssReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cbUrl = new ComboBox();
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btGoBack = new Button();
            btGoForward = new Button();
            tbTitle = new TextBox();
            btRecordAdd = new Button();
            btRecordDelete = new Button();
            ssMessageArea = new StatusStrip();
            tsslbMessage = new ToolStripStatusLabel();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripSplitButton1 = new ToolStripSplitButton();
            ColorToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            cdColor = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            ssMessageArea.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cbUrl
            // 
            cbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbUrl.Location = new Point(174, 28);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(731, 33);
            cbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(911, 26);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(75, 33);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.DrawMode = DrawMode.OwnerDrawFixed;
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.ForeColor = SystemColors.Desktop;
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(12, 101);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(974, 130);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            lbTitles.DrawItem += lbTitles_DrawItem;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(12, 237);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(974, 465);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            wvRssLink.NavigationCompleted += wvRssLink_NavigationCompleted;
            wvRssLink.SourceChanged += wvRssLink_SourceChanged;
            // 
            // btGoBack
            // 
            btGoBack.BackColor = SystemColors.ButtonHighlight;
            btGoBack.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btGoBack.ForeColor = SystemColors.Desktop;
            btGoBack.Location = new Point(12, 27);
            btGoBack.Name = "btGoBack";
            btGoBack.Size = new Size(75, 32);
            btGoBack.TabIndex = 4;
            btGoBack.Text = "戻る";
            btGoBack.UseVisualStyleBackColor = false;
            btGoBack.Click += btGoBack_Click;
            // 
            // btGoForward
            // 
            btGoForward.BackColor = SystemColors.ButtonHighlight;
            btGoForward.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btGoForward.ForeColor = SystemColors.Desktop;
            btGoForward.Location = new Point(93, 27);
            btGoForward.Name = "btGoForward";
            btGoForward.Size = new Size(75, 33);
            btGoForward.TabIndex = 5;
            btGoForward.Text = "進む";
            btGoForward.UseVisualStyleBackColor = false;
            btGoForward.Click += btGoForward_Click;
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbTitle.Location = new Point(174, 67);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(650, 26);
            tbTitle.TabIndex = 6;
            // 
            // btRecordAdd
            // 
            btRecordAdd.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordAdd.Location = new Point(830, 63);
            btRecordAdd.Name = "btRecordAdd";
            btRecordAdd.Size = new Size(75, 32);
            btRecordAdd.TabIndex = 7;
            btRecordAdd.Text = "登録";
            btRecordAdd.UseVisualStyleBackColor = true;
            btRecordAdd.Click += btRecordAdd_Click;
            // 
            // btRecordDelete
            // 
            btRecordDelete.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordDelete.Location = new Point(911, 63);
            btRecordDelete.Name = "btRecordDelete";
            btRecordDelete.Size = new Size(75, 32);
            btRecordDelete.TabIndex = 8;
            btRecordDelete.Text = "削除";
            btRecordDelete.UseVisualStyleBackColor = true;
            btRecordDelete.Click += btRecordDelete_Click;
            // 
            // ssMessageArea
            // 
            ssMessageArea.Items.AddRange(new ToolStripItem[] { tsslbMessage });
            ssMessageArea.Location = new Point(0, 705);
            ssMessageArea.Name = "ssMessageArea";
            ssMessageArea.Size = new Size(998, 22);
            ssMessageArea.TabIndex = 9;
            ssMessageArea.Text = "statusStrip1";
            // 
            // tsslbMessage
            // 
            tsslbMessage.BackColor = SystemColors.MenuBar;
            tsslbMessage.Name = "tsslbMessage";
            tsslbMessage.Size = new Size(118, 17);
            tsslbMessage.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(81, 73);
            label1.Name = "label1";
            label1.Size = new Size(87, 16);
            label1.TabIndex = 10;
            label1.Text = "お気に入り";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSplitButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(998, 25);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { ColorToolStripMenuItem, ExitToolStripMenuItem });
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(62, 22);
            toolStripSplitButton1.Text = "表示(&V)";
            // 
            // ColorToolStripMenuItem
            // 
            ColorToolStripMenuItem.Name = "ColorToolStripMenuItem";
            ColorToolStripMenuItem.Size = new Size(180, 22);
            ColorToolStripMenuItem.Text = "色設定...";
            ColorToolStripMenuItem.Click += ColorToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            ExitToolStripMenuItem.Size = new Size(180, 22);
            ExitToolStripMenuItem.Text = "終了";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 727);
            Controls.Add(toolStrip1);
            Controls.Add(label1);
            Controls.Add(ssMessageArea);
            Controls.Add(btRecordDelete);
            Controls.Add(btRecordAdd);
            Controls.Add(tbTitle);
            Controls.Add(btGoForward);
            Controls.Add(btGoBack);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Controls.Add(cbUrl);
            Name = "Form1";
            Text = "RSSリーダー";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ssMessageArea.ResumeLayout(false);
            ssMessageArea.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbUrl;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button btGoBack;
        private Button btGoForward;
        private TextBox tbTitle;
        private Button btRecordAdd;
        private Button btRecordDelete;
        private StatusStrip ssMessageArea;
        private ToolStripStatusLabel tsslbMessage;
        private Label label1;
        private ToolStrip toolStrip1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem ColorToolStripMenuItem;
        private ColorDialog cdColor;
        private ToolStripMenuItem ExitToolStripMenuItem;
    }
}
