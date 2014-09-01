namespace ShanoRPGWin.UI
{
    partial class LifeManaPanel
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
            this.lblManaNum = new System.Windows.Forms.Label();
            this.lblLifeNum = new System.Windows.Forms.Label();
            this.lblMana = new System.Windows.Forms.Label();
            this.lblLife = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblManaNum
            // 
            this.lblManaNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManaNum.AutoSize = true;
            this.lblManaNum.Location = new System.Drawing.Point(56, 37);
            this.lblManaNum.Name = "lblManaNum";
            this.lblManaNum.Size = new System.Drawing.Size(25, 13);
            this.lblManaNum.TabIndex = 7;
            this.lblManaNum.Text = "200";
            // 
            // lblLifeNum
            // 
            this.lblLifeNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLifeNum.AutoSize = true;
            this.lblLifeNum.Location = new System.Drawing.Point(56, 10);
            this.lblLifeNum.Name = "lblLifeNum";
            this.lblLifeNum.Size = new System.Drawing.Size(25, 13);
            this.lblLifeNum.TabIndex = 6;
            this.lblLifeNum.Text = "150";
            // 
            // lblMana
            // 
            this.lblMana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMana.AutoSize = true;
            this.lblMana.Location = new System.Drawing.Point(3, 37);
            this.lblMana.Name = "lblMana";
            this.lblMana.Size = new System.Drawing.Size(37, 13);
            this.lblMana.TabIndex = 5;
            this.lblMana.Text = "Mana:";
            // 
            // lblLife
            // 
            this.lblLife.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLife.AutoSize = true;
            this.lblLife.Location = new System.Drawing.Point(3, 10);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(27, 13);
            this.lblLife.TabIndex = 4;
            this.lblLife.Text = "Life:";
            // 
            // LifeManaPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblManaNum);
            this.Controls.Add(this.lblLifeNum);
            this.Controls.Add(this.lblMana);
            this.Controls.Add(this.lblLife);
            this.MaximumSize = new System.Drawing.Size(10000, 60);
            this.MinimumSize = new System.Drawing.Size(104, 60);
            this.Name = "LifeManaPanel";
            this.Size = new System.Drawing.Size(104, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManaNum;
        private System.Windows.Forms.Label lblLifeNum;
        private System.Windows.Forms.Label lblMana;
        private System.Windows.Forms.Label lblLife;
    }
}
