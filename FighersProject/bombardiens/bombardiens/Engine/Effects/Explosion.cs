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
    public class Explosion:ParticleGameObject
    {
        private float _power;
        private ObjectList _fireballs;

        public Explosion(Vector2 position, float power, ObjectList fireballs)
            : base(position, Res.randomExplosion, 255, -10, RANDOM.getRotation, 0, 0, power * 0.01f, 0, 0)
        {
            color = Color.Yellow;
            this._power = power;
            this._fireballs = fireballs;
            injectFireballs();            
        }

        public override void updatePhysics()
        {
            base.updatePhysics();

            if (alpha <= 0)
            {
                alive = false;
            }
        }

        public void injectFireballs() 
        {
            for (int i = 0; i < _power * 10; i++)
            {
                float speed = RANDOM.getFloat(5, 15);
                Fireball fireball = new Fireball(position, RANDOM.getRotation, 1, 0, speed, -1);
                _fireballs.Add(fireball);
            }
        }
    }
}
