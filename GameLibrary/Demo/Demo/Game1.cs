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
using GameLibrary;
using GameLibrary.Global;
using GameLibrary.Collision;

namespace Demo
{
    public class Game1 : GameTemplate
    {
        CollisionManager manager = new CollisionManager();

        public Game1():base()
        {

        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }


        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Graphics.spriteBatch.Begin();
            Graphics.DrawLine(new Vector2(300, 300), new Vector2(400, 400), 1, Color.Black);
            Graphics.spriteBatch.End();
        }
    }
}
