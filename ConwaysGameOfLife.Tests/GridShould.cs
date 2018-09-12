using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwaysGameOfLifeGUI;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace ConwaysGameOfLife.Tests
{
    public class GridShould
    {
        private readonly TestHelper _testHelper = new TestHelper();
        [Fact]
        public void GetTheLivingNeighboursOfALivingCell()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{0, 1, 1, 0, 0},
                new[]{0, 1, 1, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            int[][] expectedLiveNeighbourGraph =
            {
                new[]{0, 1, 1, 0, 0},
                new[]{0, 0, 1, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };
  
            var expectedLiveNeighbours= _testHelper.TransformGraphToCells(expectedLiveNeighbourGraph);
            var cellTarget = new Cell(1, 1);
            var actualLiveNeighbours = grid.GetLiveNeighboursOfALivingCell(cellTarget);

            expectedLiveNeighbours.Should().BeEquivalentTo(actualLiveNeighbours);
            Assert.Equal(3, actualLiveNeighbours.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfASingleLivingCell()
        {           
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            int[][] expectedLiveNeighboursGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedLiveNeighbours = _testHelper.TransformGraphToCells(expectedLiveNeighboursGraph);
            var cellTarget = new Cell(1, 1);
            var actualLiveNeighbours = grid.GetLiveNeighboursOfALivingCell(cellTarget);

            expectedLiveNeighbours.Should().BeEquivalentTo(actualLiveNeighbours);
            Assert.Empty(actualLiveNeighbours);
        }

        [Fact]
        public void GetTheLivingNeighboursOfALivingCellOnEdgeOfTheGrid()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{1, 0, 0, 0, 0},
                new[]{1, 0, 0, 1, 1},
                new[]{0, 0, 0, 0, 1},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            int[][] expectedLiveNeighboursGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{1, 0, 0, 0, 0},
                new[]{1, 0, 0, 1, 0},
                new[]{0, 0, 0, 0, 1},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedLiveNeighbours = _testHelper.TransformGraphToCells(expectedLiveNeighboursGraph);
            var cellTarget = new Cell(2, 4);
            var actualLiveNeighbours = grid.GetLiveNeighboursOfALivingCell(cellTarget);


            expectedLiveNeighbours.Should().BeEquivalentTo(actualLiveNeighbours);
            Assert.Equal(4, actualLiveNeighbours.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfALivingCellOnACorner()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{1, 1, 0, 0, 1},
                new[]{1, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 1}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            int[][] expectedLiveNeighboursGraph =
            {
                new[]{0, 1, 0, 0, 1},
                new[]{1, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 1}
            };

            var expectedLiveNeighbours = _testHelper.TransformGraphToCells(expectedLiveNeighboursGraph);
            var cellTarget = new Cell(0, 0);
            var actualLiveNeighbours = grid.GetLiveNeighboursOfALivingCell(cellTarget);

            expectedLiveNeighbours.Should().BeEquivalentTo(actualLiveNeighbours);
            Assert.Equal(5, actualLiveNeighbours.Count());
        }
        [Fact]
        public void GetTheDeadNeighboursOfCell()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{1, 1, 0, 0, 0},
                new[]{1, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            int[][] expectedNeighbourCellsGraph =
            {
                new[]{0, 0, 1, 0, 0},
                new[]{0, 0, 1, 0, 0},
                new[]{1, 1, 1, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedDeadNeighbours = _testHelper.TransformGraphToCells(expectedNeighbourCellsGraph);
            var cellTarget = new Cell(1, 1);
            var actualDeadNeighbours = grid.GetDeadNeighboursOfALivingCell(cellTarget);

            expectedDeadNeighbours.Should().BeEquivalentTo(expectedDeadNeighbours);
            Assert.Equal(5, actualDeadNeighbours.Count());
        }

        [Fact]
        public void GetTheDeadNeighboursOfCellInACorner()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{1, 1, 0, 0, 0},
                new[]{1, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            int[][] expectedNeighbourCellsGraph =
            {
                new[]{0, 0, 0, 0, 1},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{1, 1, 0, 0, 1}
            };

            var expectedDeadNeighbours = _testHelper.TransformGraphToCells(expectedNeighbourCellsGraph);
            var cellTarget = new Cell(1, 1);
            var actualDeadNeighbours = grid.GetDeadNeighboursOfALivingCell(cellTarget);

            expectedDeadNeighbours.Should().BeEquivalentTo(expectedDeadNeighbours);
            Assert.Equal(5, actualDeadNeighbours.Count());
        }

        [Fact]
        public void GetTheRightCellsAndItsNeighbourCountDictionary()
        {

        }
    }
}
