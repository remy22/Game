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

namespace GameLibrary.Global
{
    public static class KEYBOARD
    {
        public static KeyboardState keyboard;
        public static KeyboardState previousKeyboard;

        /// <summary>
        /// Returns true if the key was hit on this exact frame
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyPressed(Keys key)
        {
            if (KeyDown(key))
            {
                Keys[] keys = previousKeyboard.GetPressedKeys();
                return !keys.Contains(key);
            }
            return false;
        }

        /// <summary>
        /// Returns whether or not the key is being held down
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }

        public static void Update()
        {
            previousKeyboard = keyboard;
            keyboard = Keyboard.GetState();
        }
    }
}
