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
        private const int DefaultUiScale = 240;

        private static Point screenSize;

        public static double UiScale { get; private set; }

        /// <summary>
        /// Gets or sets the camera center point in game co-ordinates. 
        /// </summary>
        public static Vector2 CenterPoint { get; set; }

        /// <summary>
        /// Gets or sets the screen size in pixels. 
        /// </summary>
        public static Point ScreenSize
        {
            get { return screenSize; }
            set
            {
                screenSize = value;
                UiScale = Math.Min(ScreenHalfSize.X, ScreenHalfSize.Y);
            }
        }

        public static double FontScale
        {
            get { return UiScale / DefaultUiScale; }
        }

        public static Point ScreenHalfSize
        {
            get { return screenSize.DivideBy(2); }
        }

        /// <summary>
        /// Gets the screen co-ordinates of the given in-game point. 
        /// </summary>
        public static Point GameToScreen(Vector2 p)
        {
            return GameToScreen(p.X, p.Y);
        }

        internal static Vector2 GameToUi(Vector2 v)
        {
            return ScreenToUi(GameToScreen(v));
        }


        /// <summary>
        /// Gets the screen co-ordinates of the given in-game point. 
        /// </summary>
        public static Point GameToScreen(double x, double y)
        {
            return new Point(
                (int)((x - CenterPoint.X) * ScreenSize.X / Constants.Game.ScreenWidth) + ScreenHalfSize.X,
                (int)((y - CenterPoint.Y) * ScreenSize.Y / Constants.Game.ScreenHeight) + ScreenHalfSize.Y);
        }

        /// <summary>
        /// Gets the screen co-ordinates of the given UI point. 
        /// </summary>
        public static Point UiToScreen(Vector2 p)
        {
            return new Point(
                ScreenHalfSize.X + (int)(p.X * UiScale),
                ScreenHalfSize.Y + (int)(p.Y * UiScale));
        }

        /// <summary>
        /// Gets the screen size of the given Ui size. 
        /// </summary>
        public static int UiToScreen(double sz)
        {
            return (int)(sz * UiScale);
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

        /// <summary>
        /// Gets the UI size of the given screen size. 
        /// </summary>
        public static double ScreenToUi(int sz)
        {
            return (double)sz / UiScale;
        }
    }
}
