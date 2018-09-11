using System;
using System.Threading.Tasks;
using ConwaysGameOfLifeGUI;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ConwaysGameOfLife.Tests
{
    public class CellShould
    {
        [Fact]
        public void ReturnTrueIfCellsHaveEqualValueOfRowAndColumn()
        {
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 1);
            var isEqual = cell1.Equals(cell2);

            Assert.IsTrue(isEqual);
        }

        [Fact]
        public void ReturnFalseIfCellsHaveEqualValueOfRowOnly()
        {
            var cell1 = new Cell(1, 0);
            var cell2 = new Cell(1, 1);
            var isEqual = cell1.Equals(cell2);

            Assert.IsFalse(isEqual);
        }

        [Fact]
        public void ReturnFalseIfCellsHaveEqualValueOfColumnOnly()
        {
            var cell1 = new Cell(0, 1);
            var cell2 = new Cell(1, 1);
            var isEqual = cell1.Equals(cell2);

            Assert.IsFalse(isEqual);
        }
    }
}
