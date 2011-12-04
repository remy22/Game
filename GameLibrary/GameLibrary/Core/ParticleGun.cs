using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using GameLibrary.Global;

namespace GameLibrary.Core
{
    public class ParticleGun:AnimatedGameObject
    {
        protected int _cooldownTime = 30;
        private int cooldown = 0;
        public float muzzleVelocity = 5;
        protected float _recoil = 0.0f;

        public ParticleGun(Vector2 position, Animation animation):base(position, animation)
        {

        }

        private float recoil
        {
            get
            {
                return RANDOM.getFloat(-_recoil, _recoil);
            }
        }

        public virtual AbstractGameObject Fire()
        {
            if (readyToFire)
            {
                AbstractGameObject bullet = nextShot;
                bullet.rotation = rotation;
                bullet.velocity = GameLibrary.Global.Trig.getVelocity(bullet.rotation, muzzleVelocity);
                cooldown = _cooldownTime;
                rotation += recoil;
                return bullet;
            }
            return null;
        }

        public void randomizeDirection()
        {
            rotation = (float)RANDOM.random.NextDouble() * Trig.PI_Two;
        }

        public override string ToString()
        {
            return "ParticleGun";
        }

        public int coolDownTime
        {
            get
            {
                return _cooldownTime;
            }
            set
            {
                if (value > 0)
                {
                    _cooldownTime = value;
                }
            }
        }

        public bool readyToFire
        {
            get
            {
                return cooldown == 0;
            }
        }


        public void CoolDown()
        {
            if (!readyToFire)
            {
                cooldown--;
            }
        }

        

        public virtual AbstractGameObject nextShot
        {
            get
            {
                return null;
            }
        }

    }
}
