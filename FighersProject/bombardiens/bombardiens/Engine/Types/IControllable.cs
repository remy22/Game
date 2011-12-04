using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bombardiens.Engine.Character
{
    public interface IControllable
    {
        void moveForward();
        void moveBackward();
        void moveLeft();
        void moveRight();
        void stopMoving();
    }
}
