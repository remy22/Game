using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary;
using Microsoft.Xna.Framework;
using GameLibrary.Global;
using GameLibrary.Core;
using bombardiens.Engine.Types;
using bombardiens.Engine.CustomObjects;

namespace bombardiens.Engine.Effects
{
    public class Fireball:ParticleGameObject, IDestructableTerrainCollidable
    {
        int radius = 3;
        int lifetime = 300;
       

        public Fireball(Vector2 position, float rotation, float scale, float scaleAccel, float speed, float accel)
            : base(position,
            new Animation(Res.bullet), 155, 0, rotation, 1, scale, scaleAccel, speed, accel)
        {
 
        }

        public void destructableTerrainCollision(DestructableTerrain terrain)
        {
            if(terrain.getCollidingPixal(position, radius).Count > 4){
                terrain.damage(position, 3, GameLibrary.Global.Graphics.airColor);
                alive = false;
            }
        }

        public override void updatePhysics()
        {
            base.updatePhysics();

            if (age == lifetime - 255)
            {
                _alphaAccel = -1;
            }

            if (age > lifetime)
            {
                alive = false;
            }
        }
    }
}
