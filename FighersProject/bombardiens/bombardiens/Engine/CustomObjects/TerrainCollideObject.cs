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
using GameLibrary.Interfaces;

namespace bombardiens.Engine.CustomObjects
{
    public class TerrainCollideObject : GameLibrary.Core.AnimatedGameObject, IDestructableTerrainCollidable, ICircular
    {
        protected float _radius;

        public TerrainCollideObject(Vector2 position, Animation animation, float radius) : base(position, animation) {
            _radius = radius;
        }


        public float radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }


        public void destructableTerrainCollision(DestructableTerrain terrain)
        {
            List<Vector2> collisions = terrain.getVectorCollisions(position, (int)radius);

            if (collisions.Count < 10)
            {
                return;
            }

            for (int i = 0; i < collisions.Count; i++)
            {
                float distance = Vector2.Distance(collisions[i], position);

                if (distance < radius)
                {
                    float difference = radius - distance;
                    Vector2 relative = collisions[i] - position;
                    float perc = 1 - difference / radius;
                    Vector2 correct = new Vector2(relative.X * perc, relative.Y * perc);
                    position -= correct;
                }
            }
        }
    }
}
