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
    public class SolidTerrain:AnimatedGameObject
    {
        public SolidTerrain(Vector2 position, Animation animation)
            : base(position, animation)
        {
            color = Color.Green;
        }

        public override void collisionWith(ICollided iCollideable)
        {
            base.collisionWith(iCollideable);            

            if (iCollideable is ISolidTerrainCollidable)
            {
                (iCollideable as ISolidTerrainCollidable).solidTerrainCollision(this);
            }
        }

        public bool containsPosition(Vector2 position)
        {
            if (position.X < right)
            {
                if (position.X > left)
                {
                    if (position.Y > top)
                    {
                        return position.Y < bottom;
                    }
                }
            }
            return false;
        }
    }
}
