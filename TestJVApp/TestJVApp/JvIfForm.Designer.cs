namespace TestJVApp
{
    partial class JvIfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JvIfForm));
            this.JvIf1 = new AxJVDTLabLib.AxJVLink();
            ((System.ComponentModel.ISupportInitialize)(this.JvIf1)).BeginInit();
            this.SuspendLayout();
            // 
            // JvIf1
            // 
            this.JvIf1.Enabled = true;
            this.JvIf1.Location = new System.Drawing.Point(13, 13);
            this.JvIf1.Name = "JvIf1";
            this.JvIf1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("JvIf1.OcxState")));
            this.JvIf1.Size = new System.Drawing.Size(192, 192);
            this.JvIf1.TabIndex = 0;
            // 
            // JvIfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.JvIf1);
            this.Name = "JvIfForm";
            this.Text = "JvIfForm";
            this.Load += new System.EventHandler(this.JvIfForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JvIf1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxJVDTLabLib.AxJVLink JvIf1;
    }
}