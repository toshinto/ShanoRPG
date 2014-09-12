namespace ShanoRPGWin.UI
{
    partial class DmgDefPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMove = new System.Windows.Forms.Label();
            this.lblDef = new System.Windows.Forms.Label();
            this.lblDmg = new System.Windows.Forms.Label();
            this.lblDmgNun = new System.Windows.Forms.Label();
            this.lblDefNum = new System.Windows.Forms.Label();
            this.lblMoveSpeedNum = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblMove, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDef, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDmg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDmgNun, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDefNum, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMoveSpeedNum, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(169, 71);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblMove
            // 
            this.lblMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMove.Location = new System.Drawing.Point(0, 46);
            this.lblMove.Margin = new System.Windows.Forms.Padding(0);
            this.lblMove.Name = "lblMove";
            this.lblMove.Size = new System.Drawing.Size(84, 25);
            this.lblMove.TabIndex = 12;
            this.lblMove.Text = "MoveSpeed:";
            this.lblMove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDef
            // 
            this.lblDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDef.Location = new System.Drawing.Point(0, 23);
            this.lblDef.Margin = new System.Windows.Forms.Padding(0);
            this.lblDef.Name = "lblDef";
            this.lblDef.Size = new System.Drawing.Size(84, 23);
            this.lblDef.TabIndex = 14;
            this.lblDef.Text = "Defense:";
            this.lblDef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDmg
            // 
            this.lblDmg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDmg.Location = new System.Drawing.Point(0, 0);
            this.lblDmg.Margin = new System.Windows.Forms.Padding(0);
            this.lblDmg.Name = "lblDmg";
            this.lblDmg.Size = new System.Drawing.Size(84, 23);
            this.lblDmg.TabIndex = 13;
            this.lblDmg.Text = "Damage";
            this.lblDmg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDmgNun
            // 
            this.lblDmgNun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDmgNun.Location = new System.Drawing.Point(84, 0);
            this.lblDmgNun.Margin = new System.Windows.Forms.Padding(0);
            this.lblDmgNun.Name = "lblDmgNun";
            this.lblDmgNun.Size = new System.Drawing.Size(85, 23);
            this.lblDmgNun.TabIndex = 15;
            this.lblDmgNun.Text = "10 - 25";
            this.lblDmgNun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefNum
            // 
            this.lblDefNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefNum.Location = new System.Drawing.Point(84, 23);
            this.lblDefNum.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefNum.Name = "lblDefNum";
            this.lblDefNum.Size = new System.Drawing.Size(85, 23);
            this.lblDefNum.TabIndex = 16;
            this.lblDefNum.Text = "10";
            this.lblDefNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMoveSpeedNum
            // 
            this.lblMoveSpeedNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveSpeedNum.Location = new System.Drawing.Point(84, 46);
            this.lblMoveSpeedNum.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveSpeedNum.Name = "lblMoveSpeedNum";
            this.lblMoveSpeedNum.Size = new System.Drawing.Size(85, 25);
            this.lblMoveSpeedNum.TabIndex = 17;
            this.lblMoveSpeedNum.Text = "3.2";
            this.lblMoveSpeedNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DmgDefPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DmgDefPanel";
            this.Size = new System.Drawing.Size(169, 71);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMove;
        private System.Windows.Forms.Label lblDef;
        private System.Windows.Forms.Label lblDmg;
        internal System.Windows.Forms.Label lblDmgNun;
        internal System.Windows.Forms.Label lblDefNum;
        internal System.Windows.Forms.Label lblMoveSpeedNum;
    }
}
