using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Interfaces
{
    public interface ICollided:IBounded
    {
        void collisionWith(ICollided iCollidable);
    }
}
