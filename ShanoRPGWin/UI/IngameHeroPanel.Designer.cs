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
            this.lblName = new System.Windows.Forms.Label();
            this.spellBar1 = new ShanoRPGWin.UI.SpellBar();
            this.attributesPanel1 = new ShanoRPGWin.UI.AttributesPanel();
            this.expPanel1 = new ShanoRPGWin.UI.ExpPanel();
            this.dmgdefpanel = new ShanoRPGWin.UI.DmgDefPanel();
            this.LifeManaPanel = new ShanoRPGWin.UI.LifeManaPanel();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(142, 69);
            this.lblName.MaximumSize = new System.Drawing.Size(10000, 13);
            this.lblName.MinimumSize = new System.Drawing.Size(44, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 20);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "PESHO";
            // 
            // spellBar1
            // 
            this.spellBar1.Location = new System.Drawing.Point(0, 3);
            this.spellBar1.Name = "spellBar1";
            this.spellBar1.NSpells = 6;
            this.spellBar1.Size = new System.Drawing.Size(374, 42);
            this.spellBar1.TabIndex = 6;
            // 
            // attributesPanel1
            // 
            this.attributesPanel1.Location = new System.Drawing.Point(285, 39);
            this.attributesPanel1.MaximumSize = new System.Drawing.Size(10000, 122);
            this.attributesPanel1.MinimumSize = new System.Drawing.Size(89, 122);
            this.attributesPanel1.Name = "attributesPanel1";
            this.attributesPanel1.Size = new System.Drawing.Size(89, 122);
            this.attributesPanel1.TabIndex = 4;
            // 
            // expPanel1
            // 
            this.expPanel1.Location = new System.Drawing.Point(0, 39);
            this.expPanel1.Name = "expPanel1";
            this.expPanel1.Size = new System.Drawing.Size(283, 27);
            this.expPanel1.TabIndex = 3;
            // 
            // dmgdefpanel
            // 
            this.dmgdefpanel.Location = new System.Drawing.Point(0, 73);
            this.dmgdefpanel.MaximumSize = new System.Drawing.Size(10000, 146);
            this.dmgdefpanel.MinimumSize = new System.Drawing.Size(140, 88);
            this.dmgdefpanel.Name = "dmgdefpanel";
            this.dmgdefpanel.Size = new System.Drawing.Size(140, 88);
            this.dmgdefpanel.TabIndex = 2;
            // 
            // LifeManaPanel
            // 
            this.LifeManaPanel.Location = new System.Drawing.Point(146, 101);
            this.LifeManaPanel.MaximumSize = new System.Drawing.Size(10000, 60);
            this.LifeManaPanel.MinimumSize = new System.Drawing.Size(104, 60);
            this.LifeManaPanel.Name = "LifeManaPanel";
            this.LifeManaPanel.Size = new System.Drawing.Size(108, 60);
            this.LifeManaPanel.TabIndex = 1;
            // 
            // IngameHeroPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spellBar1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.attributesPanel1);
            this.Controls.Add(this.expPanel1);
            this.Controls.Add(this.dmgdefpanel);
            this.Controls.Add(this.LifeManaPanel);
            this.Name = "IngameHeroPanel";
            this.Size = new System.Drawing.Size(377, 161);
            this.ResumeLayout(false);

        }

        #endregion

        private LifeManaPanel LifeManaPanel;
        private DmgDefPanel dmgdefpanel;
        private ExpPanel expPanel1;
        private AttributesPanel attributesPanel1;
        private System.Windows.Forms.Label lblName;
        private SpellBar spellBar1;


    }
}
