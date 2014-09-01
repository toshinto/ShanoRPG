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
    public partial class ManyColorPicker : UserControl
    {
        public event EventHandler ColorChanged = (e, o) => { };

        private Color selectedColor;
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                selectedColor = value;
                button1.BackColor = SelectedColor;
                ColorChanged(this, new EventArgs());
            }
        }
        public ManyColorPicker()
        {
            InitializeComponent();
            SelectedColor = Color.White;
            button1.BackColor = SelectedColor;
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog()
            {
                Color = selectedColor
            };

            if (cd.ShowDialog() == DialogResult.OK)
                SelectedColor = cd.Color;
        }
    }
}
