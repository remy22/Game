using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Managers;
using GameLibrary.Interfaces;

namespace GameLibrary.Managers.YTables
{
    public class YPartition : GameObjectList
    {
        private float _top;
        private float _bottom;

        public YPartition(float top, float bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        public override void checkInternalCollisions()
        {  
            for (int i = 0; i < Count; i++)
            {
                for (int j = i; j < Count; j++)
                {
                    if (this[i].right > this[j].left && !bothOutsiders(i, j))
                    {
                        if (this[i].top < this[j].bottom && this[i].bottom > this[j].top)
                        {
                            this[i].collisionWith(this[j]);
                            this[j].collisionWith(this[i]);
                        }
                        else if (this[i].bottom > this[j].top && this[i].top < this[j].bottom)
                        {
                            this[i].collisionWith(this[j]);
                            this[j].collisionWith(this[i]);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// The collision method will be called by objects inside the given list
        /// </summary>
        /// <param name="list"></param>
        public override void checkExternalCollisions(GameObjectList list)
        {
            int start = 0;

            for (int i = 0; i < Count; i++)
            {
                for (int j = start; j < list.Count; j++)
                {
                    IGameObject a = this[i];
                    IGameObject b = list[j];
                    GameLibrary.Global.DEBUG.comparisons++;

                    if (a.right < b.left)
                    {
                        break;
                    }
                    if (a.left > b.right)
                    {
                        start++;
                        continue;
                    }
                    if (a.top > b.bottom || a.bottom < b.top)
                    {
                        continue;
                    }
                    a.collisionWith(b);
                    b.collisionWith(a);
                }
            }
        }


        private bool bothOutsiders(int indexA, int indexB)
        {
            IGameObject a = this[indexA];
            IGameObject b = this[indexB];
            return (a.top < _top && b.top < _top);
        }


    }
}
