using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwaysGameOfLifeGUI;
using ConwaysGameOfLifeGUI.EvolutionRules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;


namespace ConwaysGameOfLife.Tests
{

    public class DeadEvolutionRulesShould
    {
        private readonly Helper _testHelper = new Helper();
        private readonly DeadEvolutionRules _rules = new DeadEvolutionRules();
        //private readonly Grid _grid = new Grid(5,5);

        [Fact]
        public void GetLiveCellsThatShouldDieWhenTheyHaveLessThanTwoOrThreeNeighbours()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 1, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            var allLiveNeighboursOfAliveCells = new List<Cell>();
            foreach (var livingCell in grid.LivingCells)
            {
                allLiveNeighboursOfAliveCells.AddRange(grid.GetLiveNeighboursOfACell(livingCell));
            }

            int[][] expectedDeadCellsGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 1, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedDeadCells = _testHelper.TransformGraphToCells(expectedDeadCellsGraph);
            var neighboursOfCellsCount = grid.GetLiveCellsAndItsNumberOfLiveNeighboursDict();
            var actualDeadCells = _rules.GetLiveCellsThatShouldDie(neighboursOfCellsCount);

            expectedDeadCells.Should().BeEquivalentTo(actualDeadCells);
            Assert.Equal(2, actualDeadCells.Count);
        }
       
        [Fact]
        public void GetLiveCellsThatShouldDieWhenTheyHaveMoreThanThreeNeighbours()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{1, 1, 1, 0, 0},
                new[]{0, 1, 1, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            var allLiveNeighboursOfAliveCells = new List<Cell>();
            foreach (var livingCell in grid.LivingCells)
            {
                allLiveNeighboursOfAliveCells.AddRange(grid.GetLiveNeighboursOfACell(livingCell));
            }

            int[][] expectedDeadCellsGraph =
            {
                new[]{0, 1, 0, 0, 0},
                new[]{0, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedDeadCells = _testHelper.TransformGraphToCells(expectedDeadCellsGraph);
            var neighboursOfCellsCount = grid.GetLiveCellsAndItsNumberOfLiveNeighboursDict();
            var actualDeadCells = _rules.GetLiveCellsThatShouldDie(neighboursOfCellsCount);

            expectedDeadCells.Should().BeEquivalentTo(actualDeadCells);
            Assert.Equal(2, actualDeadCells.Count);
        }

        [Fact]
        public void GetLiveCellsThatShouldDieWhenTheyHaveNoNeighbours()
        {
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 1, 0},
                new[]{0, 0, 0, 0, 0}
            };
        
            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));
        
            var allLiveNeighboursOfAliveCells = new List<Cell>();
            foreach (var livingCell in grid.LivingCells)
            {
                allLiveNeighboursOfAliveCells.AddRange(grid.GetLiveNeighboursOfACell(livingCell));
            }
        
            int[][] expectedDeadCellsGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 1, 0},
                new[]{0, 0, 0, 0, 0}
            };
        
            var expectedDeadCells = _testHelper.TransformGraphToCells(expectedDeadCellsGraph);
            var neighboursOfCellsCount = grid.GetLiveCellsAndItsNumberOfLiveNeighboursDict();
            var actualDeadCells = _rules.GetLiveCellsThatShouldDie(neighboursOfCellsCount);

            expectedDeadCells.Should().BeEquivalentTo(actualDeadCells);
            Assert.Equal(2, actualDeadCells.Count);
        }

        [Fact]
        public void GetNoLiveCellThatShouldDieWhenTheyHaveTwoOrThreeNeighbours()
        { 
            var grid = new Grid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 1, 0, 0},
                new[]{0, 1, 0, 1, 0},
                new[]{0, 0, 1, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => grid.AddCell(cell));

            var allLiveNeighboursOfAliveCells = new List<Cell>();
            foreach (var livingCell in grid.LivingCells)
            {
                allLiveNeighboursOfAliveCells.AddRange(grid.GetLiveNeighboursOfACell(livingCell));
            }

            int[][] expectedDeadCellsGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedDeadCells = _testHelper.TransformGraphToCells(expectedDeadCellsGraph);
            var neighboursOfCellsCount = grid.GetLiveCellsAndItsNumberOfLiveNeighboursDict();
            var actualDeadCells = _rules.GetLiveCellsThatShouldDie(neighboursOfCellsCount);

            expectedDeadCells.Should().BeEquivalentTo(actualDeadCells);
            Assert.Empty(actualDeadCells);
        }
    }
}
