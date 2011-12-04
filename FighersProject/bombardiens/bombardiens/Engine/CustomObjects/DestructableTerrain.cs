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
using GameLibrary.Interfaces;
using Microsoft.Xna.Framework;
using GameLibrary.Global;
using GameLibrary.Core;
using bombardiens.Engine.Character;
using bombardiens.Engine.Types;


namespace bombardiens.Engine.CustomObjects
{
    public class DestructableTerrain:TexturedGameObject
    {
        private int _strength = 1;

        public DestructableTerrain(Vector2 position, Texture2D texture)
            : base(position, texture)
        {
        }

        public int strength
        {
            get
            {
                return _strength;
            }
        }

        public override void collisionWith(ICollided iCollideable)
        {
            if (iCollideable is IDestructableTerrainCollidable)
            {
                ((IDestructableTerrainCollidable)iCollideable).destructableTerrainCollision(this);
            }
        }
    }
}
