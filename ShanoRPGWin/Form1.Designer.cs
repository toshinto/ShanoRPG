namespace ShanoRPGWin
{
    partial class Form1
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
            this.ingameHeroPanel1 = new ShanoRPGWin.UI.IngameHeroPanel();
            this.SuspendLayout();
            // 
            // ingameHeroPanel1
            // 
            this.ingameHeroPanel1.Location = new System.Drawing.Point(235, 219);
            this.ingameHeroPanel1.Name = "ingameHeroPanel1";
            this.ingameHeroPanel1.Size = new System.Drawing.Size(377, 127);
            this.ingameHeroPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 358);
            this.Controls.Add(this.ingameHeroPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.IngameHeroPanel ingameHeroPanel1;
    }
}

