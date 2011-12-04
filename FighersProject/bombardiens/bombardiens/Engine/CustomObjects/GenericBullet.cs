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
using GameLibrary.Core;
using Microsoft.Xna.Framework;
using bombardiens.Engine.Character;
using bombardiens.Engine.Types;


namespace bombardiens.Engine.CustomObjects
{
    public class GenericBullet:AnimatedGameObject, IDestructableTerrainCollidable
    {
        private int _damage = 1;

        public void destructableTerrainCollision(DestructableTerrain terrain)
        {
            if (terrain.getCollidingPixal(position, (int)width / 2).Count > 1)
            {
                terrain.damage(position, 7, GameLibrary.Global.Graphics.airColor);
                alive = false;
            }
        }


        public GenericBullet(Vector2 position, Animation animation, int damage)
            : base(position, animation)
        {
            this._damage = damage;
        }

        public override void collisionWith(GameLibrary.Interfaces.ICollided iCollideable)
        {
            if (iCollideable is IBulletCollideable)
            {
                (iCollideable as IBulletCollideable).struckByBullet(this);
            }
        }

        public virtual bool ignore(GameLibrary.Interfaces.ICollided iCollideable)
        {
            return false;
        }

        public int damage
        {
            get
            {
                return _damage;
            }
        }

        public override string ToString()
        {
            return "BasicBullet";
        }
    }
}
