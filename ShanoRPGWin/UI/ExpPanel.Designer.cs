namespace ShanoRPGWin.UI
{
    partial class ExpPanel
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
            this.components = new System.ComponentModel.Container();
            this.ExpBar = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ExpBar
            // 
            this.ExpBar.Location = new System.Drawing.Point(0, 3);
            this.ExpBar.Name = "ExpBar";
            this.ExpBar.Size = new System.Drawing.Size(280, 23);
            this.ExpBar.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ExpBar, "66/100");
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 100;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // ExpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExpBar);
            this.Name = "ExpPanel";
            this.Size = new System.Drawing.Size(283, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ExpBar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
