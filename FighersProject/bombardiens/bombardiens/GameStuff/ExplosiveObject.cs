using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Core;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameLibrary;
using Microsoft.Xna.Framework;
using bombardiens.Engine;
using bombardiens.Engine.Character;
using GameLibrary.Global;
using bombardiens.Engine.GameRender;
using bombardiens.Engine.CustomObjects;
using bombardiens.Engine.Util;
using bombardiens.Engine.Effects;

namespace bombardiens.GameStuff
{
    public class ExplosiveObject:AnimatedGameObject
    {
        protected GameSection _gameSection;
        protected int _power;


        public ExplosiveObject(Vector2 position, Animation animation, int power, GameSection gameSection)
            : base(position, animation)
        {
            _gameSection = gameSection;
            _power = power;
        }

        public void explode()
        {
            alive = false;
            _gameSection.addExplosion(position, _power);
        }
    }
}
