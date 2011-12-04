using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Global;
using Microsoft.Xna.Framework;

namespace bombardiens.Engine
{
    public class DebugHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="vector2"></param>
        /// <param name="position"></param> The position on the screen where the text will be rendered
        public void displayVector2(String info, Vector2 vector2, Vector2 position)
        {
            Graphics.DrawString(info + " " + vector2.ToString(), position, Color.Black);
        }

        public void DrawAxis(float length, GameRender.InGameCamera camera)
        {
            Vector2 origin = Vector2.Zero;
            Vector2 y = new Vector2(0, length);
            Vector2 x = new Vector2(length, 0);
        }
    }
}
