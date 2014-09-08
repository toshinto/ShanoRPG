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
    public partial class SpellBar : UserControl
    {
        private List<SpellButton> SpellButtons = new List<SpellButton>();
        private int _nspells;
        public int NSpells
        {
            get
            {
                return _nspells; 
            }
            set
            {
                _nspells = value;
                SpellPanel.ColumnCount = value;
               
             }

        }
        public SpellBar()
        {
            InitializeComponent();
        }
    }
}
