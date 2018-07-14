namespace TestJVApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axJVLink1 = new AxJVDTLabLib.AxJVLink();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Kaisai1 = new System.Windows.Forms.Label();
            this.Kaisai2 = new System.Windows.Forms.Label();
            this.Kaisai3 = new System.Windows.Forms.Label();
            this.niigata = new System.Windows.Forms.PictureBox();
            this.tokyo = new System.Windows.Forms.Button();
            this.nakayama = new System.Windows.Forms.Button();
            this.fukushima = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.sapporo = new System.Windows.Forms.Button();
            this.hakodate = new System.Windows.Forms.Button();
            this.kyoto = new System.Windows.Forms.Button();
            this.hanshin = new System.Windows.Forms.Button();
            this.chukyo = new System.Windows.Forms.Button();
            this.kokura = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.info1 = new System.Windows.Forms.Label();
            this.returncode = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.axJVLink1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.niigata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // axJVLink1
            // 
            this.axJVLink1.Enabled = true;
            this.axJVLink1.Location = new System.Drawing.Point(223, 316);
            this.axJVLink1.Name = "axJVLink1";
            this.axJVLink1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axJVLink1.OcxState")));
            this.axJVLink1.Size = new System.Drawing.Size(35, 23);
            this.axJVLink1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-1, 292);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(285, 178);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "本日の開催";
            // 
            // Kaisai1
            // 
            this.Kaisai1.AutoSize = true;
            this.Kaisai1.Location = new System.Drawing.Point(161, 16);
            this.Kaisai1.Name = "Kaisai1";
            this.Kaisai1.Size = new System.Drawing.Size(0, 12);
            this.Kaisai1.TabIndex = 4;
            // 
            // Kaisai2
            // 
            this.Kaisai2.AutoSize = true;
            this.Kaisai2.Location = new System.Drawing.Point(161, 37);
            this.Kaisai2.Name = "Kaisai2";
            this.Kaisai2.Size = new System.Drawing.Size(0, 12);
            this.Kaisai2.TabIndex = 5;
            // 
            // Kaisai3
            // 
            this.Kaisai3.AutoSize = true;
            this.Kaisai3.Location = new System.Drawing.Point(161, 58);
            this.Kaisai3.Name = "Kaisai3";
            this.Kaisai3.Size = new System.Drawing.Size(0, 12);
            this.Kaisai3.TabIndex = 6;
            // 
            // niigata
            // 
            this.niigata.ErrorImage = ((System.Drawing.Image)(resources.GetObject("niigata.ErrorImage")));
            this.niigata.Image = ((System.Drawing.Image)(resources.GetObject("niigata.Image")));
            this.niigata.Location = new System.Drawing.Point(-1, 52);
            this.niigata.Name = "niigata";
            this.niigata.Size = new System.Drawing.Size(665, 430);
            this.niigata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.niigata.TabIndex = 8;
            this.niigata.TabStop = false;
            // 
            // tokyo
            // 
            this.tokyo.Enabled = false;
            this.tokyo.Location = new System.Drawing.Point(461, 351);
            this.tokyo.Name = "tokyo";
            this.tokyo.Size = new System.Drawing.Size(75, 23);
            this.tokyo.TabIndex = 9;
            this.tokyo.Text = "東京競馬場";
            this.tokyo.UseVisualStyleBackColor = true;
            this.tokyo.Click += new System.EventHandler(this.tokyo_Click);
            // 
            // nakayama
            // 
            this.nakayama.Enabled = false;
            this.nakayama.Location = new System.Drawing.Point(530, 316);
            this.nakayama.Name = "nakayama";
            this.nakayama.Size = new System.Drawing.Size(75, 23);
            this.nakayama.TabIndex = 10;
            this.nakayama.Text = "中山競馬場";
            this.nakayama.UseVisualStyleBackColor = true;
            this.nakayama.Click += new System.EventHandler(this.nakayama_Click);
            // 
            // fukushima
            // 
            this.fukushima.Enabled = false;
            this.fukushima.Location = new System.Drawing.Point(530, 260);
            this.fukushima.Name = "fukushima";
            this.fukushima.Size = new System.Drawing.Size(75, 23);
            this.fukushima.TabIndex = 11;
            this.fukushima.Text = "福島競馬場";
            this.fukushima.UseVisualStyleBackColor = true;
            this.fukushima.Click += new System.EventHandler(this.fukushima_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(406, 278);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "新潟競馬場";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // sapporo
            // 
            this.sapporo.Enabled = false;
            this.sapporo.Location = new System.Drawing.Point(492, 72);
            this.sapporo.Name = "sapporo";
            this.sapporo.Size = new System.Drawing.Size(75, 23);
            this.sapporo.TabIndex = 13;
            this.sapporo.Text = "札幌競馬場";
            this.sapporo.UseVisualStyleBackColor = true;
            this.sapporo.Click += new System.EventHandler(this.sapporo_Click);
            // 
            // hakodate
            // 
            this.hakodate.Enabled = false;
            this.hakodate.Location = new System.Drawing.Point(436, 122);
            this.hakodate.Name = "hakodate";
            this.hakodate.Size = new System.Drawing.Size(75, 23);
            this.hakodate.TabIndex = 14;
            this.hakodate.Text = "函館競馬場";
            this.hakodate.UseVisualStyleBackColor = true;
            this.hakodate.Click += new System.EventHandler(this.hakodate_Click);
            // 
            // kyoto
            // 
            this.kyoto.Enabled = false;
            this.kyoto.Location = new System.Drawing.Point(313, 316);
            this.kyoto.Name = "kyoto";
            this.kyoto.Size = new System.Drawing.Size(75, 23);
            this.kyoto.TabIndex = 15;
            this.kyoto.Text = "京都競馬場";
            this.kyoto.UseVisualStyleBackColor = true;
            this.kyoto.Click += new System.EventHandler(this.kyoto_Click);
            // 
            // hanshin
            // 
            this.hanshin.Enabled = false;
            this.hanshin.Location = new System.Drawing.Point(290, 345);
            this.hanshin.Name = "hanshin";
            this.hanshin.Size = new System.Drawing.Size(75, 23);
            this.hanshin.TabIndex = 16;
            this.hanshin.Text = "阪神競馬場";
            this.hanshin.UseVisualStyleBackColor = true;
            this.hanshin.Click += new System.EventHandler(this.hanshin_Click);
            // 
            // chukyo
            // 
            this.chukyo.Enabled = false;
            this.chukyo.Location = new System.Drawing.Point(380, 351);
            this.chukyo.Name = "chukyo";
            this.chukyo.Size = new System.Drawing.Size(75, 23);
            this.chukyo.TabIndex = 17;
            this.chukyo.Text = "中京競馬場";
            this.chukyo.UseVisualStyleBackColor = true;
            this.chukyo.Click += new System.EventHandler(this.chukyo_Click);
            // 
            // kokura
            // 
            this.kokura.Enabled = false;
            this.kokura.Location = new System.Drawing.Point(142, 351);
            this.kokura.Name = "kokura";
            this.kokura.Size = new System.Drawing.Size(75, 23);
            this.kokura.TabIndex = 18;
            this.kokura.Text = "小倉競馬場";
            this.kokura.UseVisualStyleBackColor = true;
            this.kokura.Click += new System.EventHandler(this.kokura_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(151, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 19);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // info1
            // 
            this.info1.AutoSize = true;
            this.info1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.info1.Location = new System.Drawing.Point(53, 87);
            this.info1.Name = "info1";
            this.info1.Size = new System.Drawing.Size(241, 19);
            this.info1.TabIndex = 21;
            this.info1.Text = "開催情報を取得していません。";
            // 
            // returncode
            // 
            this.returncode.AutoSize = true;
            this.returncode.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.returncode.Location = new System.Drawing.Point(625, 10);
            this.returncode.Name = "returncode";
            this.returncode.Size = new System.Drawing.Size(0, 18);
            this.returncode.TabIndex = 22;
            this.returncode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.returncode.UseCompatibleTextRendering = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 141);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(295, 19);
            this.textBox2.TabIndex = 23;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 472);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.Size = new System.Drawing.Size(676, 22);
            this.statusBar1.TabIndex = 24;
            this.statusBar1.Text = "statusBar1";
            this.statusBar1.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar1_PanelClick);
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "statusBarPanel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 494);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.returncode);
            this.Controls.Add(this.info1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.kokura);
            this.Controls.Add(this.chukyo);
            this.Controls.Add(this.hanshin);
            this.Controls.Add(this.kyoto);
            this.Controls.Add(this.hakodate);
            this.Controls.Add(this.sapporo);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.fukushima);
            this.Controls.Add(this.nakayama);
            this.Controls.Add(this.tokyo);
            this.Controls.Add(this.niigata);
            this.Controls.Add(this.Kaisai3);
            this.Controls.Add(this.Kaisai2);
            this.Controls.Add(this.Kaisai1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axJVLink1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axJVLink1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.niigata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxJVDTLabLib.AxJVLink axJVLink1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Kaisai1;
        private System.Windows.Forms.Label Kaisai2;
        private System.Windows.Forms.Label Kaisai3;
        private System.Windows.Forms.PictureBox niigata;
        private System.Windows.Forms.Button tokyo;
        private System.Windows.Forms.Button nakayama;
        private System.Windows.Forms.Button fukushima;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button sapporo;
        private System.Windows.Forms.Button hakodate;
        private System.Windows.Forms.Button kyoto;
        private System.Windows.Forms.Button hanshin;
        private System.Windows.Forms.Button chukyo;
        private System.Windows.Forms.Button kokura;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label info1;
        private System.Windows.Forms.Label returncode;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
    }
}

