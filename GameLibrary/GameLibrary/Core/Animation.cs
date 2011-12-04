using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using GameLibrary.Global;

namespace GameLibrary.Core
{
    [Serializable]
    public class Animation
    {
        private String _textureName;
        private int nextFrame;
        private int frameCount;
        private int _currentFrame = 0;
        private int frameRate = 6; // how many frames between currentFrames
        public Vector2 origin = Vector2.Zero;
        private int frameWidth = 0;
        private Rectangle drawRectangle;


        public Animation(string textureName, int frameCount)
        {
            FrameCount = frameCount;
            this.textureName = textureName;
            nextFrame = frameRate;
        }

        public Animation(string textureName)
        {
            FrameCount = 1;
            this.textureName = textureName;
            nextFrame = frameRate;
        }
        
        public String textureName
        {
            get
            {
                return _textureName;
            }
            set
            {
                _textureName = value;
                frameWidth = texture2D.Width / frameCount;
            }
        }

        public Rectangle DrawRectangle
        {
            get { return drawRectangle; }
        }


        public Texture2D texture2D
        {
            get
            {
                return Graphics.dictionary[_textureName];
            }
        }

        public Animation DeepCopy
        {
            get
            {
                return new Animation(_textureName, frameCount);
            }
        }
       

        public int currentFrame
        {
            get
            {
                return _currentFrame;
            }
            set
            {
                _currentFrame = value % frameCount;
            }
        }

        public int FrameCount
        {
            get
            {
                return frameCount;
            }
            set
            {
                frameCount = value;
            }
        }

        /// <summary>
        /// The number of updates cycles per frame change
        /// </summary>
        public int FrameRate
        {
            get
            {
                return frameRate;
            }
            set
            {
                if (value > 0)
                {
                    frameRate = value;
                }
            }
        }


        /// <summary>
        /// The width of the scaled animation
        /// </summary>
        public int Width(float scale)
        {
              return (int)(scale * frameWidth);
        }


        /// <summary>
        /// The height of the scaled animation
        /// </summary>
        public int Height(float scale)
        {
            return (int)(scale * texture2D.Height);
        }


        public void CenterOrigin()
        {
            origin = new Vector2((texture2D.Width / frameCount) / 2, texture2D.Height / 2);
        }

        public void Play(Vector2 position, Color colour, float rotation, float scale, float layerDepth, SpriteEffects spriteEffects)
        {
            Texture2D texture = texture2D;
            nextFrame--;
            if (nextFrame <= 0)
            {
                nextFrame = frameRate;
                currentFrame++;
            }
            drawRectangle = new Rectangle((int)position.X, 
                (int)position.Y, 
                (int)(scale * frameWidth), 
                (int)(scale * texture2D.Height));
            Graphics.spriteBatch.Draw(texture, drawRectangle, new Rectangle(frameWidth * _currentFrame, 0, texture.Width / frameCount, texture.Height), colour, rotation, origin, spriteEffects, 0);
        }
    }
}
