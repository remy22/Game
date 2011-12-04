using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using GameLibrary.Interfaces;
using GameLibrary.Global;
using Microsoft.Xna.Framework.Graphics;

namespace GameLibrary.Core
{
    [Serializable]
    public class AnimatedGameObject : AbstractGameObject
    {
        private Animation _animation;

        public AnimatedGameObject(Vector2 position, Animation animation):base(position)
        {
            this.animation = animation;
        } 


        public Animation animation
        {
            get
            {
                return _animation;
            }
            set
            {
                if (value != null)
                {
                    _animation = value;
                    _animation.CenterOrigin();
                }
            }
        }

        public override float width
        {
            get
            {
                return animation.Width(scale);
            }
        }

        public override float height
        {
            get
            {
                return animation.Height(scale);
            }
        }

        public override void draw(Vector2 position, float rotation)
        {
            animation.Play(position, color, rotation, scale, layerDepth, spriteEffects);
        }
    }
}
