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
using System.ComponentModel;
using System.Text;
using GameLibrary.Global;


namespace GameLibrary
{
    [Serializable]
    public class GameTemplate : Microsoft.Xna.Framework.Game
    {
        public Keys ExitKey = Keys.Escape;
        private int frameRate = 0;
        private int frameCounter = 0;
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private int _frame = 0;



        public GameTemplate():base()
        {
            Content.RootDirectory = "Content";
            Graphics.graphics = new GraphicsDeviceManager(this);
            Screen.SetSize(800, 600);  
        }        

        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Graphics.LoadGraphics(this);
            Global.Screen.window = Window;
        }

        public void ExitGame()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MOUSE.Update();
            KEYBOARD.Update();
            _frame++;

            if (KEYBOARD.KeyDown(ExitKey))
            {
                ExitGame();
            }
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
        }

        public int fps
        {
            get
            {
                return frameRate;
            }
        }

        public String framesPerSecond
        {
            get
            {
                return string.Format("fps: {0}", frameRate);
            }
        }

        public int frame
        {
            get
            {
                return _frame;
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            frameCounter++;

        }
    }
}
