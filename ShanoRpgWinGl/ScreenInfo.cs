using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShanoRpgWinGl
{
    /// <summary>
    /// Contains information about the current camera, screen and UI parameters. 
    /// </summary>
    static class ScreenInfo
    {
        /// <summary>
        /// Gets or sets the camera center point in game co-ordinates. 
        /// </summary>
        public static Vector2 CenterPoint { get; set; }

        /// <summary>
        /// Gets or sets the screen size in pixels. 
        /// </summary>
        public static Point ScreenSize { get; set; }

        /// <summary>
        /// Gets the screen co-ordinates of the given in-game point. 
        /// </summary>
        public static Point GameToScreen(Vector2 p)
        {
            return GameToScreen(p.X, p.Y);
        }

        /// <summary>
        /// Gets the screen co-ordinates of the given in-game point. 
        /// </summary>
        public static Point GameToScreen(double x, double y)
        {
            return new Point(
                (int)((x - CenterPoint.X) * ScreenSize.X / Constants.Game.ScreenWidth) + ScreenSize.X / 2,
                (int)((y - CenterPoint.Y) * ScreenSize.Y / Constants.Game.ScreenHeight) + ScreenSize.Y / 2);
        }

        /// <summary>
        /// Gets the screen co-ordinates of the given UI point. 
        /// </summary>
        public static Point UiToScreen(Vector2 p)
        {
            var rx = ScreenSize.X / 2;
            var ry = ScreenSize.Y / 2;
            var scale = Math.Min(rx, ry);

            return new Point(
                rx + (int)(p.X * scale),
                ry + (int)(p.Y * scale));
        }

        public static Vector2 ScreenToUi(Point p)
        {
            var rx = ScreenSize.X / 2;
            var ry = ScreenSize.Y / 2;
            var scale = Math.Min(rx, ry);

            return new Vector2(
                (float)(p.X - rx) / scale,
                (float)(p.Y - ry) / scale);
        }
    }
}
