namespace ShanoRPGWin.UI
{
    partial class StartPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.heroSelectPanel1 = new ShanoRPGWin.UI.HeroSelectPanel();
            this.heroSelectPanel2 = new ShanoRPGWin.UI.HeroSelectPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.heroSelectPanel1);
            this.flowLayoutPanel1.Controls.Add(this.heroSelectPanel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(412, 323);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // heroSelectPanel1
            // 
            this.heroSelectPanel1.Location = new System.Drawing.Point(3, 3);
            this.heroSelectPanel1.Name = "heroSelectPanel1";
            this.heroSelectPanel1.Size = new System.Drawing.Size(250, 74);
            this.heroSelectPanel1.TabIndex = 0;
            // 
            // heroSelectPanel2
            // 
            this.heroSelectPanel2.Location = new System.Drawing.Point(3, 83);
            this.heroSelectPanel2.Name = "heroSelectPanel2";
            this.heroSelectPanel2.Size = new System.Drawing.Size(250, 74);
            this.heroSelectPanel2.TabIndex = 1;
            // 
            // StartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "StartPanel";
            this.Size = new System.Drawing.Size(418, 488);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private HeroSelectPanel heroSelectPanel1;
        private HeroSelectPanel heroSelectPanel2;
    }
}
