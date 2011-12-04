using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace GameLibrary.Global
{
    public static class MOUSE
    {        
        /// <summary>
        /// Current Mouse State
        /// </summary>
        private static MouseState mouseC;
        /// <summary>
        /// Previous Mouse State
        /// </summary>
        private static MouseState mouseP;


        /// <summary>
        /// Mouse's screen coordinate rectangle
        /// </summary>
        public static Rectangle RectangleSC
        {
            get
            {
                return new Rectangle(mouseC.X, mouseC.Y, 1, 1);
            }
        }

        public static bool MiddlePressed
        {
            get
            {
                if(mouseC.MiddleButton == ButtonState.Pressed){
                    return mouseP.MiddleButton == ButtonState.Released;
                } 
                return false;
            }
        }

        public static bool MiddleDown
        {
            get
            {
                if (mouseC.MiddleButton == ButtonState.Pressed)
                {
                    return mouseP.MiddleButton == ButtonState.Pressed;
                }
                return false;
            }
        }

        /// <summary>
        /// Mouse's world coordinate rectangle
        /// </summary>
        public static Rectangle RectangleWC
        {
            get
            {
                return new Rectangle(mouseC.X, mouseC.Y, 1, 1);
            }
        }

        /// <summary>
        /// Returns whether the left clicker is currently down
        /// </summary>
        public static bool LeftDown
        {
            get
            {
                return mouseC.LeftButton == ButtonState.Pressed;
            }
        }


        /// <summary>
        /// Returns whether the left clicker is currently down
        /// </summary>
        public static bool RightDown
        {
            get
            {
                return mouseC.RightButton == ButtonState.Pressed;
            }
        }


        /// <summary>
        /// Determines whether the mouse was left clicked on this frame
        /// </summary>
        public static bool LeftClicked
        {
            get
            {
                return LeftDown && mouseP.LeftButton == ButtonState.Released;
            }
        }

        /// <summary>
        /// Determines whether the mouse was right clicked on this frame
        /// </summary>
        public static bool RightClicked
        {
            get
            {
                return RightDown && mouseP.RightButton == ButtonState.Released;
            }
        }

        /// <summary>
        /// The screen coordinate of the mouse
        /// </summary>
        public static Vector2 SC
        {
            get
            {
                return new Vector2(mouseC.X, mouseC.Y);
            }
        }


        public static MouseState PreviousMouse
        {
            get
            {
                return mouseP;
            }
        }      

        public static bool OnScreen
        {
            get
            {
                return RectangleSC.Intersects(Screen.rectangle);
            }
        }

        public static int ScrollWheelVal
        {
            get
            {
                return mouseC.ScrollWheelValue;
            }
        }


        public static void Update()
        {
            mouseP = mouseC;
            mouseC = Mouse.GetState();
        }

        public static Vector2 velocity
        {
            get
            {
                float x = mouseC.X - mouseP.X;
                float y = mouseC.Y - mouseP.Y;
                return new Vector2(x, y);
            }
        }
    }
}
