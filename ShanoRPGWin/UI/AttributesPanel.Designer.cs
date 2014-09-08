namespace ShanoRPGWin.UI
{
    partial class AttributesPanel
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
            this.lblStr = new System.Windows.Forms.Label();
            this.lblStrNum = new System.Windows.Forms.Label();
            this.lblAgi = new System.Windows.Forms.Label();
            this.lblAgiNum = new System.Windows.Forms.Label();
            this.lblVit = new System.Windows.Forms.Label();
            this.lblVitNum = new System.Windows.Forms.Label();
            this.lblInt = new System.Windows.Forms.Label();
            this.lblIntNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStr
            // 
            this.lblStr.AutoSize = true;
            this.lblStr.Location = new System.Drawing.Point(16, 18);
            this.lblStr.Name = "lblStr";
            this.lblStr.Size = new System.Drawing.Size(23, 13);
            this.lblStr.TabIndex = 0;
            this.lblStr.Text = "Str:";
            // 
            // lblStrNum
            // 
            this.lblStrNum.AutoSize = true;
            this.lblStrNum.Location = new System.Drawing.Point(48, 18);
            this.lblStrNum.Name = "lblStrNum";
            this.lblStrNum.Size = new System.Drawing.Size(19, 13);
            this.lblStrNum.TabIndex = 1;
            this.lblStrNum.Text = "20";
            // 
            // lblAgi
            // 
            this.lblAgi.AutoSize = true;
            this.lblAgi.Location = new System.Drawing.Point(17, 41);
            this.lblAgi.Name = "lblAgi";
            this.lblAgi.Size = new System.Drawing.Size(25, 13);
            this.lblAgi.TabIndex = 2;
            this.lblAgi.Text = "Agi:";
            // 
            // lblAgiNum
            // 
            this.lblAgiNum.AutoSize = true;
            this.lblAgiNum.Location = new System.Drawing.Point(48, 41);
            this.lblAgiNum.Name = "lblAgiNum";
            this.lblAgiNum.Size = new System.Drawing.Size(19, 13);
            this.lblAgiNum.TabIndex = 3;
            this.lblAgiNum.Text = "15";
            // 
            // lblVit
            // 
            this.lblVit.AutoSize = true;
            this.lblVit.Location = new System.Drawing.Point(17, 65);
            this.lblVit.Name = "lblVit";
            this.lblVit.Size = new System.Drawing.Size(22, 13);
            this.lblVit.TabIndex = 4;
            this.lblVit.Text = "Vit:";
            // 
            // lblVitNum
            // 
            this.lblVitNum.AutoSize = true;
            this.lblVitNum.Location = new System.Drawing.Point(48, 65);
            this.lblVitNum.Name = "lblVitNum";
            this.lblVitNum.Size = new System.Drawing.Size(19, 13);
            this.lblVitNum.TabIndex = 5;
            this.lblVitNum.Text = "40";
            // 
            // lblInt
            // 
            this.lblInt.AutoSize = true;
            this.lblInt.Location = new System.Drawing.Point(17, 93);
            this.lblInt.Name = "lblInt";
            this.lblInt.Size = new System.Drawing.Size(22, 13);
            this.lblInt.TabIndex = 6;
            this.lblInt.Text = "Int:";
            // 
            // lblIntNum
            // 
            this.lblIntNum.AutoSize = true;
            this.lblIntNum.Location = new System.Drawing.Point(48, 93);
            this.lblIntNum.Name = "lblIntNum";
            this.lblIntNum.Size = new System.Drawing.Size(19, 13);
            this.lblIntNum.TabIndex = 7;
            this.lblIntNum.Text = "23";
            // 
            // AttributesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIntNum);
            this.Controls.Add(this.lblInt);
            this.Controls.Add(this.lblVitNum);
            this.Controls.Add(this.lblVit);
            this.Controls.Add(this.lblAgiNum);
            this.Controls.Add(this.lblAgi);
            this.Controls.Add(this.lblStrNum);
            this.Controls.Add(this.lblStr);
            this.MaximumSize = new System.Drawing.Size(10000, 122);
            this.MinimumSize = new System.Drawing.Size(89, 122);
            this.Name = "AttributesPanel";
            this.Size = new System.Drawing.Size(89, 122);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStr;
        private System.Windows.Forms.Label lblStrNum;
        private System.Windows.Forms.Label lblAgi;
        private System.Windows.Forms.Label lblAgiNum;
        private System.Windows.Forms.Label lblVit;
        private System.Windows.Forms.Label lblVitNum;
        private System.Windows.Forms.Label lblInt;
        private System.Windows.Forms.Label lblIntNum;
    }
}
