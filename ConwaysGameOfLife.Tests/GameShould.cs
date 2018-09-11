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
    public class GameShould
    {
        [Fact]
        public void ReturnAnEmptyGridWhenAllALiveCellsDie()
        {
            var game = new GameOfLife();
            var initialLivingCells = new List<Cell> { new Cell(1, 1), new Cell(1, 0), new Cell(3, 3) };
            game.SetGridSize(5, 5);
            initialLivingCells.ForEach(cell => { game.AddLivingCell(cell);  });

            game.Evolve();
            var actuaLivingCells = game.LivingCells;

            Assert.Empty(actuaLivingCells);
        }

        [Fact]
        public void KeepTheStateOfTheGridAsNoCellDies()
        {
            var game = new GameOfLife();
            var initialLivingCells = new List<Cell> { new Cell(1, 0), new Cell(1, 1), new Cell(2, 0), new Cell(2, 1) };
            game.SetGridSize(5, 5);
            initialLivingCells.ForEach(cell => { game.AddLivingCell(cell); });

            game.Evolve();//debug
            var expectedLiveCells = new List<Cell> { new Cell(1, 0), new Cell(1, 1), new Cell(2, 0), new Cell(2, 1) };
            var actualLivingCells = game.LivingCells;

            expectedLiveCells.Should().BeEquivalentTo(actualLivingCells);
            Assert.Equal(4, actualLivingCells.Count());
        }

        [Fact]
        public void RemoveCellsFromGridWhenMultipleLiveCellsDieAndAddCellsThatShouldBecomeAlive()
        {
            var game = new GameOfLife();
            var initialLivingCells = new List<Cell> { new Cell(1, 1), new Cell(1, 2), new Cell(1, 3), new Cell(2,1)};
            game.SetGridSize(5, 5);
            initialLivingCells.ForEach(cell => { game.AddLivingCell(cell); });

            game.Evolve();
            var expectedLiveCells = new List<Cell> { new Cell(1, 1), new Cell(1, 2), new Cell(1, 3), new Cell(0, 2) };
            var actualLivingCells = game.LivingCells;

            expectedLiveCells.Should().BeEquivalentTo(actualLivingCells);
            Assert.Equal(4, actualLivingCells.Count());
        }

        [Fact]
        public void AddADeadCellToGridWhenCellLives()
        {
            var game = new GameOfLife();
            var initialLivingCells = new List<Cell> { new Cell(0, 1), new Cell(0, 2), new Cell(1, 0) };
            game.SetGridSize(5, 5);
            initialLivingCells.ForEach(cell => { game.AddLivingCell(cell); });

            game.Evolve();
            var expectedLiveCells = new List<Cell> { new Cell(1, 1) };
            var actualLivingCells = game.LivingCells;

            expectedLiveCells.Should().BeEquivalentTo(actualLivingCells);
            Assert.Single(actualLivingCells);
        }
    }
}
