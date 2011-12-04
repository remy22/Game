using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using GameLibrary.Interfaces;
using GameLibrary.Global;
using Microsoft.Xna.Framework.Graphics;


namespace GameLibrary.Core
{
    public class ParticleGameObject:AnimatedGameObject
    {
        private float _rotationAccel;
        private float _scaleAccel;
        private float _accel;
        private int _alpha;
        protected int _alphaAccel;
        private int _age = 0;

        

        public ParticleGameObject(Vector2 position, Animation animation, int alpha, int alphaAccel, float rotation, float rotationAccel,
            float scale, float scaleAccel, float speed, float accel)
            : base(position, animation)
        {
            _alphaAccel = alphaAccel;
            _rotationAccel = rotationAccel;
            _scaleAccel = scaleAccel;

            this.rotation = rotation;
            this.color = color;
            this.scale = scale;
            velocity = Trig.getVelocity(rotation, speed);
            _accel = accel;

            _alpha = alpha;
            _alphaAccel = alphaAccel;
        }

        public int age
        {
            get
            {
                return _age;
            }
        }

        protected int alpha
        {
            get
            {
                return color.A;
            }set{
                _alpha = (int)MathHelper.Clamp(value, 0, 255);
                color.A = (byte)_alpha;
            }
        }

        public override void updatePhysics()
        {
            acceleration = Trig.getVelocity(rotation, _accel);
            alpha += _alphaAccel;
            rotation += _rotationAccel;
            scale += _scaleAccel;
            _age++;
            base.updatePhysics();
        }
    }
}
