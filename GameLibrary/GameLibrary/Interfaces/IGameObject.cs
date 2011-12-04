using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Core;
using GameLibrary.Interfaces;

namespace GameLibrary.Interfaces
{
    public interface IGameObject : IDisplayed, ICollided, IComparable<IGameObject>, IPhysical
    {
        bool alive { get; set; }
        void update();
    }
}
