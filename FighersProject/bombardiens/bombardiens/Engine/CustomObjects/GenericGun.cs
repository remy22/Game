using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Core;
using Microsoft.Xna.Framework;


namespace bombardiens.Engine.CustomObjects
{
    public class GenericGun:ParticleGun
    {
        private int damage = 10;

        public GenericGun(Vector2 position, Animation animation)
            : base(position, animation)
        {
            coolDownTime = 3;
            _recoil = 0.1f;
        }

        public override AbstractGameObject nextShot
        {
            get
            {
                return new GenericBullet(gunTip, new Animation(Res.bullet), damage);
            }
        }

        public Vector2 gunTip
        {
            get
            {
                return GameLibrary.Global.Trig.MoveToCurrentDirection(position, rotation, height / 2);
            }
        }
    }
}
