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
using GameLibrary.Core;
using GameLibrary.Interfaces;
using GameLibrary.Global;

namespace bombardiens.Engine.Util
{
    public class InGameMouse
    {
        public float sensitivity = 0.005f;

        public void update()
        {
            CenterCursor();
        }

        private void CenterCursor()
        {
            Mouse.SetPosition(Screen.width / 2, Screen.height / 2);
        }

        public void doRotate(IRotated iRotated)
        {
            iRotated.rotation += velocity.X / 500;           
        }

        public Vector2 velocity
        {
            get
            {
                return MOUSE.SC - Screen.center;
            }
        }

        public void rotate(IRotated iRotated)
        {
            iRotated.rotation += velocity.X * sensitivity;
        }
    }
}
