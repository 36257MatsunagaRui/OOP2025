using System;

namespace UnitConverter {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.tbNum2 = new System.Windows.Forms.TextBox();
            this.tbNum1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btChange = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudNum1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudNum2 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudAnswer = new System.Windows.Forms.NumericUpDown();
            this.btCalc = new System.Windows.Forms.Button();
            this.nudAmari = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmari)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UD デジタル 教科書体 NP", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Location = new System.Drawing.Point(40, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "距離換算アプリ";
            // 
            // tbNum2
            // 
            this.tbNum2.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum2.Location = new System.Drawing.Point(64, 338);
            this.tbNum2.Name = "tbNum2";
            this.tbNum2.Size = new System.Drawing.Size(158, 41);
            this.tbNum2.TabIndex = 1;
            // 
            // tbNum1
            // 
            this.tbNum1.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum1.Location = new System.Drawing.Point(64, 144);
            this.tbNum1.Name = "tbNum1";
            this.tbNum1.Size = new System.Drawing.Size(158, 41);
            this.tbNum1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(110, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "変換前";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(110, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "変換後";
            // 
            // btChange
            // 
            this.btChange.BackColor = System.Drawing.Color.Azure;
            this.btChange.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btChange.ForeColor = System.Drawing.Color.SkyBlue;
            this.btChange.Location = new System.Drawing.Point(89, 219);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(116, 47);
            this.btChange.TabIndex = 5;
            this.btChange.Text = "変換";
            this.btChange.UseVisualStyleBackColor = false;
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(12, 604);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "🦀";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(251, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "🐟";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "🐟";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(447, 604);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "🐚";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(60, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "🐟";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(230, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "🐠";
            // 
            // nudNum1
            // 
            this.nudNum1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudNum1.Location = new System.Drawing.Point(12, 470);
            this.nudNum1.Name = "nudNum1";
            this.nudNum1.Size = new System.Drawing.Size(120, 31);
            this.nudNum1.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label10.Location = new System.Drawing.Point(138, 470);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 31);
            this.label10.TabIndex = 13;
            this.label10.Text = "÷";
            // 
            // nudNum2
            // 
            this.nudNum2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudNum2.Location = new System.Drawing.Point(179, 470);
            this.nudNum2.Name = "nudNum2";
            this.nudNum2.Size = new System.Drawing.Size(120, 31);
            this.nudNum2.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label11.Location = new System.Drawing.Point(305, 470);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 31);
            this.label11.TabIndex = 15;
            this.label11.Text = "＝";
            // 
            // nudAnswer
            // 
            this.nudAnswer.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudAnswer.Location = new System.Drawing.Point(346, 467);
            this.nudAnswer.Name = "nudAnswer";
            this.nudAnswer.Size = new System.Drawing.Size(120, 31);
            this.nudAnswer.TabIndex = 16;
            // 
            // btCalc
            // 
            this.btCalc.BackColor = System.Drawing.Color.Azure;
            this.btCalc.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btCalc.ForeColor = System.Drawing.Color.SkyBlue;
            this.btCalc.Location = new System.Drawing.Point(360, 557);
            this.btCalc.Name = "btCalc";
            this.btCalc.Size = new System.Drawing.Size(92, 38);
            this.btCalc.TabIndex = 17;
            this.btCalc.Text = "計算";
            this.btCalc.UseVisualStyleBackColor = false;
            this.btCalc.Click += new System.EventHandler(this.btCalc_Click);
            // 
            // nudAmari
            // 
            this.nudAmari.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudAmari.Location = new System.Drawing.Point(346, 509);
            this.nudAmari.Name = "nudAmari";
            this.nudAmari.Size = new System.Drawing.Size(120, 31);
            this.nudAmari.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("UD デジタル 教科書体 NK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label12.Location = new System.Drawing.Point(278, 516);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 24);
            this.label12.TabIndex = 19;
            this.label12.Text = "あまり";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.ForeColor = System.Drawing.Color.OrangeRed;
            this.label14.Location = new System.Drawing.Point(307, 604);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 19);
            this.label14.TabIndex = 21;
            this.label14.Text = "🦀";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.ForeColor = System.Drawing.Color.DarkGray;
            this.label13.Location = new System.Drawing.Point(155, 604);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 19);
            this.label13.TabIndex = 22;
            this.label13.Text = "🐚";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label16.Location = new System.Drawing.Point(85, 534);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 19);
            this.label16.TabIndex = 24;
            this.label16.Text = "🐠";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label18.Location = new System.Drawing.Point(251, 402);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 19);
            this.label18.TabIndex = 26;
            this.label18.Text = "🐟";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("UD デジタル 教科書体 NP", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label15.Location = new System.Drawing.Point(93, 417);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 34);
            this.label15.TabIndex = 27;
            this.label15.Text = "割り算";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.ForeColor = System.Drawing.Color.Tan;
            this.label17.Location = new System.Drawing.Point(438, 445);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 19);
            this.label17.TabIndex = 28;
            this.label17.Text = "🐢";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(477, 632);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudAmari);
            this.Controls.Add(this.btCalc);
            this.Controls.Add(this.nudAnswer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudNum2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudNum1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btChange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNum1);
            this.Controls.Add(this.tbNum2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudNum1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudNum2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudAnswer;
        private System.Windows.Forms.Button btCalc;
        private System.Windows.Forms.NumericUpDown nudAmari;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
    }
}

