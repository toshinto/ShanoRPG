namespace ShanoRPGWin.UI
{
    partial class SpellBar
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
            this.SpellPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // SpellPanel
            // 
            this.SpellPanel.ColumnCount = 2;
            this.SpellPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SpellPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SpellPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpellPanel.Location = new System.Drawing.Point(0, 0);
            this.SpellPanel.Name = "SpellPanel";
            this.SpellPanel.RowCount = 1;
            this.SpellPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SpellPanel.Size = new System.Drawing.Size(811, 44);
            this.SpellPanel.TabIndex = 0;
            // 
            // SpellBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SpellPanel);
            this.Name = "SpellBar";
            this.Size = new System.Drawing.Size(811, 44);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel SpellPanel;
    }
}
