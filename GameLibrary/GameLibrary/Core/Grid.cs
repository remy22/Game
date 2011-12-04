using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Core
{
    public class Grid
    {
        public GridSquare[,] squareArray;

        public Grid(int columns, int rows)
        {
            squareArray = new GridSquare[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    GridSquare gridSquare = new GridSquare(x,y);
                    squareArray[columns, rows] = gridSquare;
                }
            }
        }        
    }
}
