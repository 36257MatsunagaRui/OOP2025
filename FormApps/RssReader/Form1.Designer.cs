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
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            ssMessageArea.SuspendLayout();
            SuspendLayout();
            // 
            // cbUrl
            // 
            cbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbUrl.Location = new Point(174, 13);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(731, 33);
            cbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(911, 12);
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
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.ForeColor = SystemColors.Desktop;
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(12, 87);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(974, 172);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(12, 265);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(974, 404);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            wvRssLink.NavigationCompleted += wvRssLink_NavigationCompleted;
            wvRssLink.SourceChanged += wvRssLink_SourceChanged;
            // 
            // btGoBack
            // 
            btGoBack.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btGoBack.Location = new Point(12, 13);
            btGoBack.Name = "btGoBack";
            btGoBack.Size = new Size(75, 32);
            btGoBack.TabIndex = 4;
            btGoBack.Text = "戻る";
            btGoBack.UseVisualStyleBackColor = true;
            btGoBack.Click += btGoBack_Click;
            // 
            // btGoForward
            // 
            btGoForward.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btGoForward.Location = new Point(93, 13);
            btGoForward.Name = "btGoForward";
            btGoForward.Size = new Size(75, 33);
            btGoForward.TabIndex = 5;
            btGoForward.Text = "進む";
            btGoForward.UseVisualStyleBackColor = true;
            btGoForward.Click += btGoForward_Click;
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbTitle.Location = new Point(174, 55);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(650, 26);
            tbTitle.TabIndex = 6;
            // 
            // btRecordAdd
            // 
            btRecordAdd.Font = new Font("BIZ UDゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordAdd.Location = new Point(830, 52);
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
            btRecordDelete.Location = new Point(911, 51);
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
            ssMessageArea.Location = new Point(0, 672);
            ssMessageArea.Name = "ssMessageArea";
            ssMessageArea.Size = new Size(998, 22);
            ssMessageArea.TabIndex = 9;
            ssMessageArea.Text = "statusStrip1";
            // 
            // tsslbMessage
            // 
            tsslbMessage.Name = "tsslbMessage";
            tsslbMessage.Size = new Size(118, 17);
            tsslbMessage.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 694);
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
    }
}
