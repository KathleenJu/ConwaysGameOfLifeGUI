using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeGUI.Cel
{
    public class CellComparer : IEqualityComparer<Cell>
    {
        public bool Equals(Cell cell1, Cell cell2)
        {
            return cell1.Row == cell2.Row && cell1.Column == cell2.Column;
    }

        public int GetHashCode(Cell obj)
        {
            return obj.Row.GetHashCode() ^ obj.Row.GetHashCode();
        }
    }
}
