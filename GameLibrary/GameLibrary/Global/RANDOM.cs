using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Global
{
    public static class RANDOM
    {
        public static Random random = new Random((new Random()).Next(0, 1000));


        public static float getFloat(float min, float max)
        {
            float val = (float)random.NextDouble() * max;
            if (getBool)
            {
                return -val;
            }
            return val;
        }

        public static float getRotation
        {
            get
            {
                return getFloat(0, Trig.PI_Two);
            }
        }

        public static bool getBool
        {
            get
            {
                return random.Next(0, 10) % 2 == 0;
            }
        }
    }
}
