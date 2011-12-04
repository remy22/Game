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
    public class TexturedGameObject : AbstractGameObject
    {
        [NonSerialized]
        private Texture2D _texture2D;
        private Vector2 _origin = new Vector2();
        private Color[] colors;
        private bool damaged = false;


        public TexturedGameObject(Vector2 position, Texture2D texture2D)
            : base(position)
        {
            this.texture2D = texture2D;
        }

        public Texture2D texture2D
        {
            get
            {
                return _texture2D;
            }
            set
            {
                _origin = new Vector2(value.Width / 2, value.Height / 2);
                colors = new Color[value.Width * value.Height];
                value.GetData(colors);
                _texture2D = new Texture2D(Graphics.graphics.GraphicsDevice, value.Width, value.Height, false, SurfaceFormat.Color);
                _texture2D.SetData(colors);
            }
        }

        public void setTexture(Color[] colors)
        {
            this.colors = colors;
            repair();
        }

        public void repair()
        {
            _texture2D.SetData(colors);
        }

        public Vector2 origin
        {
            get
            {
                return _origin;
            }
        }

        public override float width
        {
            get
            {
                return _texture2D.Width * scale;
            }
        }

        public override float height
        {
            get
            {
                return _texture2D.Height * scale;
            }
        }

        public List<int> getCollidingPixal(Vector2 pos, int radius)
        {
            float relX = pos.X - left;
            int l = (int)Math.Max(relX - radius, 0);
            int r = (int)Math.Min(relX + radius, _texture2D.Width);

            float relY = pos.Y - top;
            int t = (int)Math.Max(relY - radius, 0);
            int b = (int)Math.Min(relY + radius, _texture2D.Height);

            List<int> list = new List<int>();

            for (int row = t; row < b; row++)
            {
                for (int column = l; column < r; column++)
                {
                    int index = (column + row * _texture2D.Width);
                    if (colors[index] != Graphics.airColor)
                    {
                        list.Add(index);
                    }
                }
            }
            return list;
        }


        public List<Vector2> getVectorCollisions(Vector2 pos, int radius)
        {
            List<int> pixalIndices = getCollidingPixal(pos, radius);
            List<Vector2> vectors = new List<Vector2>();

            for (int i = 0; i < pixalIndices.Count; i++)
            {
                vectors.Add(getPixalPosition(pixalIndices[i]));
            }
            return vectors;
        }

        public Vector2 getPixalPosition(int pixalIndex)
        {
            float c = pixalIndex % _texture2D.Width - _origin.X;
            float r = pixalIndex / _texture2D.Height - _origin.Y;
            return new Vector2(c + position.X, r + position.Y);
        }

        private int getPixalRow(int index)
        {
            return index / _texture2D.Width;
        }

        private int getPixalColumn(int index)
        {
            return index % _texture2D.Width;
        }

        public void damage(Vector2 pos, int radius, Color color)
        {
            List<int> list = getCollidingPixal(pos, radius);
            for (int i = 0; i < list.Count; i++)
            {
                colors[list[i]] = color;
            }
            damaged = true;
        }

        public override void draw(Vector2 position, float rotation)
        {
            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height);

            if (damaged)
            {
                repair();
            }

            Graphics.spriteBatch.Draw(_texture2D, destination, null, color, rotation, _origin, spriteEffects, layerDepth);
        }

    }
}
