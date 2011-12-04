using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Global
{
    public class DEBUG
    {
        public static int comparisons;
        public static int cameraChecks; 

        public static int total
        {
            get
            {
                return comparisons + cameraChecks;
            }
        }

        public static void reset()
        {
            comparisons = 0;
            cameraChecks = 0;
        }
    }
}
