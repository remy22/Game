using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Core
{
    public class GridSquare
    {
        private int column;
        private int row;

        public GridSquare(int column, int row)
        {
            this.column = column;
            this.row = row;
        }
    }
}
