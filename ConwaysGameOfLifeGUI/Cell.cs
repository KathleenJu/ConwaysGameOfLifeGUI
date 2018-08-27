using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeGUI
{
    public class Cell
    {
        public int Row { get; }
        public int Column { get; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object cellObj)
        {
            var cell = (Cell)cellObj;
            return cell.Row == Row && cell.Column == Column;
        }
    }
}
