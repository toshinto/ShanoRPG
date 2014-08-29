using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Engine.Maps
{
    public class Map
    {
        public readonly int Width, Height;

        public readonly MapTile[,] Tiles;

        public Map(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Toq fail go nqma e");

            Bitmap mapFile = (Bitmap)Image.FromFile(path);

            this.Width = mapFile.Width;
            this.Height = mapFile.Height;

            this.Tiles = new MapTile[Width, Height];


            for(int ix = 0; ix < Width; ix++)
                for(int iy = 0; iy < Height; iy++)
                {
                    var tileColor = mapFile.GetPixel(ix, iy);

                    if (tileColor == Color.Green)
                        Tiles[ix, iy] = MapTile.Grass;
                    else if (tileColor == Color.Brown)
                        Tiles[ix, iy] = MapTile.Dirt;
                    else if (tileColor == Color.Blue)
                        Tiles[ix, iy] = MapTile.Water;
                    else if (tileColor == Color.Gray)
                        Tiles[ix, iy] = MapTile.Stone;
                    else
                        throw new Exception("Unrecognized color: " + tileColor.ToString());
                }
                
        }
    }
}
