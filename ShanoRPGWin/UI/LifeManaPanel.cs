using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShanoRPGWin.UI
{
    public partial class LifeManaPanel : UserControl
    {
        public int Life
        {
            set
            {
                lblLifeNum.Text = value.ToString();
            }
        }
        public int Mana
        {
            set
            {
                lblManaNum.Text = value.ToString(); 
            }
        }
        public LifeManaPanel()
        {
            InitializeComponent();
        }
    }
}
