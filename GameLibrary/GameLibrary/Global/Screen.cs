using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameLibrary.Global
{
    public static class Screen
    {
        private static Vector2 _center;
        private static Rectangle _rectangle = new Rectangle(0, 0, 1, 1);
        public static GameWindow window;

        public static void SetSize(int _width, int _height)
        {
            width = _width;
            height = _height;
        }

        public static int width
        {
            get
            {
                return Graphics.graphics.PreferredBackBufferWidth;
            }
            set
            {
                _center.X = value / 2;
                _rectangle.Width = value;
                Graphics.graphics.PreferredBackBufferWidth = value;
                Graphics.graphics.ApplyChanges();
            }
        }

        public static int height
        {
            get
            {
                return Graphics.graphics.PreferredBackBufferHeight;
            }
            set
            {
                _rectangle.Height = value;
                _center.Y = value / 2;
                Graphics.graphics.PreferredBackBufferHeight = value;
                Graphics.graphics.ApplyChanges();
            }
        }

        public static Vector2 center
        {
            get
            {
                return _center;
            }
        }

        public static Rectangle rectangle
        {
            get
            {
                return _rectangle;
            }
        }

        public static String title
        {
            get
            {
                return window.Title;
            }
            set
            {
                window.Title = value;
            }
        }
    }
}
