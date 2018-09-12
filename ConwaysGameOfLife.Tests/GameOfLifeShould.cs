using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLifeGUI;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;


namespace ConwaysGameOfLife.Tests
{
    public class GameOfLifeShould
    {
        private readonly Helper _testHelper = new Helper();
        private readonly GameOfLife _gameOfLife = new GameOfLife();

        [Fact]
        public void ReturnAnEmptyGridWhenAllALiveCellsDie()
        {
            _gameOfLife.SetGrid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 1, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => _gameOfLife.AddCellToGrid(cell));

            _gameOfLife.Evolve();

            int[][] expectedLiveCellsGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedLiveCells = _testHelper.TransformGraphToCells(expectedLiveCellsGraph);
            var actualLivingCells = _gameOfLife.LivingCells;

            expectedLiveCells.Should().BeEquivalentTo(actualLivingCells);
            Assert.Empty(actualLivingCells);
        }

        [Fact]
        public void KeepTheStateOfTheGridAsNoCellDies()
        {
            _gameOfLife.SetGrid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{1, 1, 0, 0, 0},
                new[]{1, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => _gameOfLife.AddCellToGrid(cell));

            _gameOfLife.Evolve();

            int[][] expectedLiveCellsGraph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{1, 1, 0, 0, 0},
                new[]{1, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedLiveCells = _testHelper.TransformGraphToCells(expectedLiveCellsGraph);
            var actualLivingCells = _gameOfLife.LivingCells;

            expectedLiveCells.Should().BeEquivalentTo(actualLivingCells);
            Assert.Equal(4, actualLivingCells.Count());
        }


        [Fact]
        public void RemoveCellsFromGridWhenMultipleLiveCellsDieAndAddCellsThatShouldBecomeAlive()
        {
            _gameOfLife.SetGrid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 0, 0},
                new[]{0, 1, 1, 1, 0},
                new[]{0, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => _gameOfLife.AddCellToGrid(cell));

            _gameOfLife.Evolve();

            int[][] expectedLiveCellsGraph =
            {
                new[]{0, 0, 1, 0, 0},
                new[]{0, 1, 1, 0, 0},
                new[]{0, 1, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0}
            };

            var expectedLiveCells = _testHelper.TransformGraphToCells(expectedLiveCellsGraph);
            var actualLivingCells = _gameOfLife.LivingCells;

            expectedLiveCells.Should().BeEquivalentTo(actualLivingCells);
            Assert.Equal(4, actualLivingCells.Count());
        }

        [Fact]
        public void WrapCellsToTheOtherSide()
        {
            _gameOfLife.SetGrid(5, 5);
            int[][] graph =
            {
                new[]{0, 0, 0, 1, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 1, 1}
            };

            _testHelper.TransformGraphToCells(graph).ForEach(cell => _gameOfLife.AddCellToGrid(cell));

            _gameOfLife.Evolve();

            int[][] expectedLiveCellsGraph =
            {
                new[]{0, 0, 0, 1, 1},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0},
                new[]{0, 0, 0, 1, 1}
            };

            var expectedLiveCells = _testHelper.TransformGraphToCells(expectedLiveCellsGraph);
            var actualLivingCells = _gameOfLife.LivingCells;

            expectedLiveCells.Should().BeEquivalentTo(actualLivingCells);
            Assert.Equal(4, actualLivingCells.Count());
        }
    }
}
