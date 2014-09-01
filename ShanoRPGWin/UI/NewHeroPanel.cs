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
    public partial class NewHeroPanel : UserControl
    {
        private Color[] skinColors = new[]
            {
                Color.FromArgb(255, 255, 128),
                Color.FromArgb(255, 192, 128),
                Color.FromArgb(255, 192, 64),
                Color.FromArgb(192, 100, 50),
            };

        private Tuple<Color, string>[] staffColors = new[] 
            {
                new Tuple<Color, string>(Color.SaddleBrown, "Birchwood"),
                new Tuple<Color, string>(Color.SandyBrown, "Sandwood"),
                new Tuple<Color, string>(Color.SaddleBrown, "Saddlewood"),
                new Tuple<Color, string>(Color.Brown, "Oakwood"),
                new Tuple<Color, string>(Color.GhostWhite, "Whitewood"),
            };

        public Color SkinColor { get; private set; }
        public Color StaffColor { get; private set; }
        public Color MainColor { get; private set; }
        public Color SecondaryColor { get; private set; }

        public NewHeroPanel()
        {
            InitializeComponent();

            SkinColor = skinColors[0];
            StaffColor = staffColors[0].Item1;
            MainColor = Color.DarkGray;
            SecondaryColor = Color.Red;
            
            updateImage();

            foreach (var c in skinColors)
                skinPicker.Add(c);

            foreach (var staff in staffColors)
                staffPicker.Add(staff.Item1, staff.Item2);

            mainColorPicker.SelectedColor = MainColor;
            secondColorPicker.SelectedColor = SecondaryColor;
        }

        private void skinPicker_ColorSelected(Color c)
        {
            SkinColor = c;

            updateImage();
        }

        private void updateImage()
        {
            picBox.Image = ShanoRPGWin.UI.Drawing.HeroImageGenerator.GenerateVylshebnik(MainColor, SecondaryColor, SkinColor, StaffColor);
        }

        private void staffPicker_ColorSelected(Color c)
        {
            StaffColor = c;

            updateImage();
        }

        private void skinPicker_Load(object sender, EventArgs e)
        {

        }

        private void mainColorPicker_ColorChanged(object sender, EventArgs e)
        {
            MainColor = mainColorPicker.SelectedColor;

            updateImage();
        }

        private void secondColorPicker_ColorChanged(object sender, EventArgs e)
        {
            SecondaryColor = secondColorPicker.SelectedColor;

            updateImage();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnNapred.Enabled = txtName.Text.Length > 0;
        }
    }
}
