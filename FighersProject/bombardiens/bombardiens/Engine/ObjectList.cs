using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Managers;
using bombardiens.Engine.GameRender;
using bombardiens.Engine.CustomObjects;
using GameLibrary.Managers.YTables;

namespace bombardiens.Engine
{
    

    public class ObjectList:YTable
    {
        public float subDivide = 1;

        public ObjectList(float subdivisions, int partitionHeight):base(partitionHeight)
        {
            this.subDivide = subdivisions;
        }

        public void updateToCamera(InGameCamera camera, int frame)
        {
            if (Count == 0) return;

            float batchSize = Count / subDivide;
            float drawFrame = frame % subDivide;
            float start = batchSize * drawFrame;
            float end = start + batchSize;

            for (float i = start; i < end; i++)
            {               
                camera.checkToDraw(this[(int)i]);
            }
        }
    }
}
