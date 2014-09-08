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
            this.attributesPanel1 = new ShanoRPGWin.UI.AttributesPanel();
            this.damageDefenseMoveSpeed1 = new ShanoRPGWin.UI.DamageDefenseMoveSpeed();
            this.LifeManaPanel = new ShanoRPGWin.UI.LifeManaPanel();
            this.expPanel1 = new ShanoRPGWin.UI.ExpPanel();
            this.SuspendLayout();
            // 
            // attributesPanel1
            // 
            this.attributesPanel1.Location = new System.Drawing.Point(290, 4);
            this.attributesPanel1.MaximumSize = new System.Drawing.Size(10000, 122);
            this.attributesPanel1.MinimumSize = new System.Drawing.Size(89, 122);
            this.attributesPanel1.Name = "attributesPanel1";
            this.attributesPanel1.Size = new System.Drawing.Size(89, 122);
            this.attributesPanel1.TabIndex = 3;
            // 
            // damageDefenseMoveSpeed1
            // 
            this.damageDefenseMoveSpeed1.Location = new System.Drawing.Point(3, 38);
            this.damageDefenseMoveSpeed1.MaximumSize = new System.Drawing.Size(10000, 146);
            this.damageDefenseMoveSpeed1.MinimumSize = new System.Drawing.Size(140, 88);
            this.damageDefenseMoveSpeed1.Name = "damageDefenseMoveSpeed1";
            this.damageDefenseMoveSpeed1.Size = new System.Drawing.Size(140, 88);
            this.damageDefenseMoveSpeed1.TabIndex = 2;
            // 
            // LifeManaPanel
            // 
            this.LifeManaPanel.Location = new System.Drawing.Point(149, 57);
            this.LifeManaPanel.MaximumSize = new System.Drawing.Size(10000, 60);
            this.LifeManaPanel.MinimumSize = new System.Drawing.Size(104, 60);
            this.LifeManaPanel.Name = "LifeManaPanel";
            this.LifeManaPanel.Size = new System.Drawing.Size(104, 60);
            this.LifeManaPanel.TabIndex = 1;
            this.LifeManaPanel.Load += new System.EventHandler(this.LifeManaPanel_Load);
            // 
            // expPanel1
            // 
            this.expPanel1.Location = new System.Drawing.Point(13, 22);
            this.expPanel1.MaximumSize = new System.Drawing.Size(1000, 29);
            this.expPanel1.MinimumSize = new System.Drawing.Size(281, 29);
            this.expPanel1.Name = "expPanel1";
            this.expPanel1.Size = new System.Drawing.Size(281, 29);
            this.expPanel1.TabIndex = 4;
            // 
            // IngameHeroPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expPanel1);
            this.Controls.Add(this.attributesPanel1);
            this.Controls.Add(this.damageDefenseMoveSpeed1);
            this.Controls.Add(this.LifeManaPanel);
            this.MaximumSize = new System.Drawing.Size(10000, 124);
            this.MinimumSize = new System.Drawing.Size(371, 124);
            this.Name = "IngameHeroPanel";
            this.Size = new System.Drawing.Size(371, 124);
            this.Load += new System.EventHandler(this.IngameHeroPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LifeManaPanel LifeManaPanel;
        private DamageDefenseMoveSpeed damageDefenseMoveSpeed1;
        private AttributesPanel attributesPanel1;
        private ExpPanel expPanel1;


    }
}
