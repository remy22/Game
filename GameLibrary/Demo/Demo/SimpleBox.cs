using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Collision;
using Microsoft.Xna.Framework;

namespace Demo
{
    public class SimpleBox:IBounded
    {
        public Rectangle rectangle;

        public float left()
        {
            return rectangle.Left;
        }

        public float right()
        {
            return rectangle.Right;
        }

        public float top()
        {
            return rectangle.Top;
        }

        public float bottom()
        {
            return rectangle.Bottom;
        }

        public void collision(IBounded iBounded)
        {
            throw new NotImplementedException();
        }
    }
}
