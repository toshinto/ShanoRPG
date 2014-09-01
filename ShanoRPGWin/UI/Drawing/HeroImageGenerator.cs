using ShanoRPGWin.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanoRPGWin.UI.Drawing
{
    class HeroImageGenerator
    {
        private static Bitmap VylshebnikBase = Resources.hero;


        public static Bitmap GenerateVylshebnik(Color main, Color secondary, Color skin, Color staff)
        {
            Bitmap b = VylshebnikBase.Clone(new Rectangle(0, 0, VylshebnikBase.Width, VylshebnikBase.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            b.MakeTransparent(Color.White);

            //var bd = b.LockBits(
            //    new Rectangle(0, 0, b.Width, b.Height),
            //    System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            
            for(int ix = 0; ix < b.Width; ix++)
                for (int iy = 0; iy < b.Height; iy++)
                {
                    var c = b.GetPixel(ix, iy);

                    if (c == Color.FromArgb(0, 0, 255))
                        b.SetPixel(ix, iy, main);
                    else if (c == Color.FromArgb(255, 0, 0))
                        b.SetPixel(ix, iy, secondary);
                    else if (c == Color.FromArgb(255, 255, 0))
                        b.SetPixel(ix, iy, skin);
                    else if (c == Color.FromArgb(0, 255, 0))
                        b.SetPixel(ix, iy, staff);
                }

            return b;
        }
    }
}
