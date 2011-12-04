using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Core;
using GameLibrary.Interfaces;

namespace GameLibrary.Managers
{
    public class GameObjectList:List<IGameObject>
    {        
        public virtual void checkInternalCollisions()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = i; j < Count; j++)
                {
                    if (this[i].right > this[j].left)
                    {
                        if (this[i].top < this[j].bottom && this[i].bottom > this[j].top)
                        {
                            this[i].collisionWith(this[j]);
                        }
                        else if (this[i].bottom > this[j].top && this[i].top < this[j].bottom)
                        {
                            this[i].collisionWith(this[j]);
                        }                        
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public void removeDead()
        {
            for (int i = 0; i < Count; i++)
            {
                if (!this[i].alive)
                {
                    RemoveAt(i);
                    i--;
                }
            }
        }
   

        /// <summary>
        /// The collision method will be called by objects inside the given list
        /// </summary>
        /// <param name="list"></param>
        public virtual void checkExternalCollisions(GameObjectList list)
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

        public void updateObjectPhysics()
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].updatePhysics();
            }
        }

        public void updateGameObjects()
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].update();
            }
        }
    }
}
