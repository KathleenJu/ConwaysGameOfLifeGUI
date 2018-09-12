using System;
using ConwaysGameOfLifeGUI;
using ConwaysGameOfLifeGUI.EvolutionRules;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;

namespace ConwaysGameOfLife.Tests
{
    public class LiveEvolutionRulesShould
    {
        private readonly TestHelper _testHelper = new TestHelper();
        private readonly LiveEvolutionRules _rules = new LiveEvolutionRules();
        //private readonly Grid _grid = new Grid(5,5);

        [Fact]
        public void GetTheDeadCellThatShouldBecomeAliveWhenItHasThreeLiveNeighbours()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 1, 1, 0},
                new[]{0, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            var allDeadNeighboursOfAliveCells = new List<Cell>();
            foreach (var livingCell in grid.GetLivingCells())
            {
                allDeadNeighboursOfAliveCells.AddRange(grid.GetDeadNeighboursOfALivingCell(livingCell));
            }

            int[][] expectedLiveCellsGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 1, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedLiveCells = _testHelper.TransformGraphToCells(expectedLiveCellsGraph);
            var actualLiveCells = _rules.GetDeadCellsThatShouldLive(allDeadNeighboursOfAliveCells);

            expectedLiveCells.Should().BeEquivalentTo(actualLiveCells);
            Assert.Single(actualLiveCells);
        }


        [Fact]
        public void GetNoDeadCellsThatShouldBecomeAliveWhenTheyDoNotHaveThreeLiveNeighbours()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 0, 1, 0},
                new[]{1, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            var allDeadNeighboursOfAliveCells = new List<Cell>();
            foreach (var livingCell in grid.GetLivingCells())
            {
                allDeadNeighboursOfAliveCells.AddRange(grid.GetDeadNeighboursOfALivingCell(livingCell));
            }            

            int[][] expectedLiveCellsGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedLiveCells = _testHelper.TransformGraphToCells(expectedLiveCellsGraph);           
            var cellsThatShouldLive = _rules.GetDeadCellsThatShouldLive(allDeadNeighboursOfAliveCells);

            expectedLiveCells.Should().BeEquivalentTo(expectedLiveCells);
            Assert.Empty(cellsThatShouldLive);
        }
    }
}
