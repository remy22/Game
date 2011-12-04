using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bombardiens.Engine.CustomObjects;

namespace bombardiens.Engine.Types
{
    public interface IDestructableTerrainCollidable
    {
        void destructableTerrainCollision(DestructableTerrain terrain);
    }
}
