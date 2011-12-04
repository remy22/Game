using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameLibrary;
using Microsoft.Xna.Framework;
using GameLibrary.Core;

namespace bombardiens.Demo
{
    public class Game1: GameTemplate
    {
        Res gameGraphics = new Res();
        DemoLevel demoLevel;
        SpriteBatch spriteBatch2;



        public Game1():base()
        {
            spriteBatch2 = new SpriteBatch(GraphicsDevice);
          //  GameLibrary.Global.Graphics.graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            gameGraphics.Load();
            GameLibrary.Global.Screen.SetSize(1200, 600);
            demoLevel = new DemoLevel();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!GameLibrary.Global.KEYBOARD.KeyDown(Keys.P))
            {
                demoLevel.Update();
            }

            if (GameLibrary.Global.KEYBOARD.KeyDown(Keys.Escape))
            {
                Exit();
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            // GameLibrary.Global.Graphics.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);          
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GameLibrary.Global.Graphics.spriteBatch.Begin();  
            demoLevel.Draw();
            GameLibrary.Global.Graphics.DrawString(framesPerSecond, new Vector2(10, GameLibrary.Global.Screen.height - 20), Color.White);
            GameLibrary.Global.Graphics.spriteBatch.End();
        }
    }
}
