namespace ShanoRPGWin.UI
{
    partial class IngameHeroPanel
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
            this.LifeManaPanel = new ShanoRPGWin.UI.LifeManaPanel();
            this.damageDefenseMoveSpeed1 = new ShanoRPGWin.UI.DamageDefenseMoveSpeed();
            this.SuspendLayout();
            // 
            // LifeManaPanel
            // 
            this.LifeManaPanel.Location = new System.Drawing.Point(346, 341);
            this.LifeManaPanel.MaximumSize = new System.Drawing.Size(10000, 60);
            this.LifeManaPanel.MinimumSize = new System.Drawing.Size(104, 60);
            this.LifeManaPanel.Name = "LifeManaPanel";
            this.LifeManaPanel.Size = new System.Drawing.Size(104, 60);
            this.LifeManaPanel.TabIndex = 1;
            this.LifeManaPanel.Load += new System.EventHandler(this.LifeManaPanel_Load);
            // 
            // damageDefenseMoveSpeed1
            // 
            this.damageDefenseMoveSpeed1.Location = new System.Drawing.Point(499, 326);
            this.damageDefenseMoveSpeed1.MaximumSize = new System.Drawing.Size(10000, 146);
            this.damageDefenseMoveSpeed1.MinimumSize = new System.Drawing.Size(140, 88);
            this.damageDefenseMoveSpeed1.Name = "damageDefenseMoveSpeed1";
            this.damageDefenseMoveSpeed1.Size = new System.Drawing.Size(140, 88);
            this.damageDefenseMoveSpeed1.TabIndex = 2;
            // 
            // IngameHeroPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.damageDefenseMoveSpeed1);
            this.Controls.Add(this.LifeManaPanel);
            this.Name = "IngameHeroPanel";
            this.Size = new System.Drawing.Size(754, 541);
            this.Load += new System.EventHandler(this.IngameHeroPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LifeManaPanel LifeManaPanel;
        private DamageDefenseMoveSpeed damageDefenseMoveSpeed1;


    }
}
