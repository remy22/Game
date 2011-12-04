using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using GameLibrary.Interfaces;
using GameLibrary.Global;
using Microsoft.Xna.Framework.Graphics;


namespace GameLibrary.Core
{
    public class AbstractGameObject:IGameObject
    {
        public Vector2 _position = Vector2.Zero;
        private float _rotation = 0;
        public float scale = 1.0f;
        public Color color = Color.White;
        public float depth = 0;
        private bool _alive = true;
        public float layerDepth = 0;
        public SpriteEffects spriteEffects = SpriteEffects.None;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 acceleration = Vector2.Zero;


        public AbstractGameObject()
        {
        }

        public AbstractGameObject(Vector2 position)
        {
            this._position = position;
        }

        public virtual void updatePhysics()
        {
            velocity += acceleration;
            _position += velocity;
            acceleration = Vector2.Zero;
        }

        public virtual void update() { }

        public Vector2 position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }


        public bool alive
        {
            get{
                return _alive;
            }set{
                _alive = value;
            }
        }


        public int CompareTo(IGameObject gameObject)
        {
            float thisLeft = left;
            float theirLeft = gameObject.left;

            if (thisLeft < theirLeft)
            {
                return -1;
            }
            else if (thisLeft > theirLeft)
            {
                return 1;
            }
            return 0;
        }



        public float rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value % Trig.PI_Two;
                if (_rotation < 0)
                {
                    _rotation = Trig.PI_Two + _rotation;
                }
            }
        }

        public virtual float width
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual float height
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float left
        {
            get
            {
                return _position.X - width / 2;
            }
            set
            {
                _position.X = value + width / 2;
            }

        }

        public float right
        {
            get
            {
                return _position.X + width / 2;
            }
            set
            {
                _position.X = value - width / 2;
            }
        }

        public float top
        {
            get
            {
                return _position.Y - height / 2;
            }
            set
            {
                _position.Y = value + height / 2;
            }
        }

        public float bottom
        {
            get
            {
                return _position.Y + height / 2;
            }
            set
            {
                _position.Y = value - height / 2;
            }
        }

        public virtual void collisionWith(GameLibrary.Interfaces.ICollided iCollideable) { }

        public virtual void draw(Vector2 position, float rotation)
        {
            throw new NotImplementedException();
        }
    }
}
