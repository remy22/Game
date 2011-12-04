using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Interfaces;
using Microsoft.Xna.Framework;

namespace GameLibrary.Managers
{
    public class QuadGrid
    {
        public GameObjectList topLeft = new GameObjectList();
        public GameObjectList topRight = new GameObjectList();
        public GameObjectList bottomLeft = new GameObjectList();
        public GameObjectList bottomRight = new GameObjectList();
        private Vector2 _middle = Vector2.Zero;

        public void registerObject(IGameObject iCollided)
        {
            if (iCollided.left <= _middle.X)
            {
                if (iCollided.top < _middle.Y)
                {
                    topLeft.Add(iCollided);
                }
                else
                {
                    bottomLeft.Add(iCollided);
                }
            }
            else
            {
                if (iCollided.top < _middle.Y)
                {
                    topRight.Add(iCollided);
                }
                else
                {
                    bottomRight.Add(iCollided);
                }
            }
        }
        public void updateQuads()
        {
            for (int i = 0; i < topLeft.Count; i++)
            {
                if (topLeft[i].left > _middle.X || topLeft[i].top > _middle.Y)
                {
                    topLeft.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < topRight.Count; i++)
            {
                if (topRight[i].right < _middle.X || topLeft[i].top > _middle.Y)
                {
                    topRight.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < bottomLeft.Count; i++)
            {
                if (bottomLeft[i].left < _middle.X || topLeft[i].bottom < _middle.Y)
                {
                    bottomLeft.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < bottomRight.Count; i++)
            {
                if (bottomRight[i].right < _middle.X || bottomRight[i].bottom < _middle.Y)
                {
                    bottomRight.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
