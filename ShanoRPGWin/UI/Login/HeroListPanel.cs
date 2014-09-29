using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Objects;
using ShanoRpgWin;
using Engine;
using ShanoRpgWinGl;
using IO;
using System.Threading;
using IO;
using Local;

namespace ShanoRPGWin.UI
{
    public partial class HeroListPanel : UserControl
    {
        public HeroSelectPanel SelectedHero { get; private set; }


        public HeroListPanel()
        {
            InitializeComponent();

            loadHeroes();
        }

        private void loadHeroes()
        {
            if (!Program.DesignMode)
            {
                pHeroes.Controls.Clear();
                LocalHeroes.LoadHeroes();
                if (LocalHeroes.Heroes.Any())
                {
                    foreach (var h in LocalHeroes.Heroes)
                    {
                        AddHeroPanel(h);
                    }
                }
            }
        }

        private void toggleNoHero()
        {

        }

        public void AddHeroPanel(Hero h)
        {
            var pan = new HeroSelectPanel(h)
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left,
            };


            this.pHeroes.Controls.Add(pan);
            pan.MouseClick += pan_MouseClick;
            pan.MouseDoubleClick += pan_MouseDoubleClick;

            foreach (var lastRow in pHeroes.RowStyles.Cast<RowStyle>())
            {
                lastRow.Height = 64;
                lastRow.SizeType = SizeType.Absolute;
            }
        }

        void pan_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(SelectedHero != null)
            {
                btnPlay_Click(null, null);
            }
        }

        void pan_MouseClick(object sender, MouseEventArgs e)
        {
            var ctrl = sender as HeroSelectPanel;

            if (SelectedHero != ctrl)
            {
                if (SelectedHero != null)
                    SelectedHero.Selected = false;

                if(ctrl != null)
                    ctrl.Selected = true;

                SelectedHero = ctrl;
                btnPlay.Enabled = SelectedHero != null;
            }

            base.OnMouseClick(e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var name = "<enter hero name>";
            if (InputBox.Show(ref name) == DialogResult.OK)
            {
                if(LocalHeroes.Heroes.Any(h => h.Name == name))
                {
                    MessageBox.Show("A hero with the same name already exists!");
                    return;
                }

                if(name.Any(c => !char.IsLetter(c)))
                {
                    MessageBox.Show("The hero name must contain only letters. ");
                    return;
                }

                new Hero(name).Save();
            }
            loadHeroes();
        }

        static Random rnd = new Random();

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
            var h = SelectedHero.Hero;

            int mapSeed = -1;
            if(!int.TryParse(textBox1.Text, out mapSeed))
            {
                mapSeed = rnd.Next(0, 1 << 16);
            }
            var t = new Thread(() =>
            {
                LocalShano theGame = new LocalShano(mapSeed, h);
            });
            t.Start();


            Application.ExitThread();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
