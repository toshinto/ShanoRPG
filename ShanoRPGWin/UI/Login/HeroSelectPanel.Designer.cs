namespace ShanoRPGWin.UI
{
    partial class HeroSelectPanel
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
            this.SuspendLayout();
            // 
            // HeroSelectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(999999, 64);
            this.MinimumSize = new System.Drawing.Size(0, 64);
            this.Name = "HeroSelectPanel";
            this.Size = new System.Drawing.Size(264, 64);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HeroSelectPanel_Paint);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
