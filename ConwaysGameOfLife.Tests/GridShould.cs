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
        [Fact]
        public void GetTheLivingNeighboursOfALivingCell()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(0, 2));
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(1, 2)
            };
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(3, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfASingleLivingCell()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            var expectedNeighbourCells = new List<Cell>();
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Empty(actualNeighbourCells);
        }

        [Fact]
        public void GetTheLivingNeighboursOfALivingCellWithSparseNeighbours()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(4, 4));
            grid.AddCell(new Cell(1, 3));
            grid.AddCell(new Cell(3, 1));
            grid.AddCell(new Cell(0, 2));
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(0, 2),
                new Cell(1, 2)
            };
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(2, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfALivingCellOnEdgeOfTheGrid()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(2, 4);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(2, 0));
            grid.AddCell(new Cell(2, 3));
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(3, 4));
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(2, 0),
                new Cell(2, 3),
                new Cell(3, 4)
            };
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(3, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfALivingCellOnACorner()
        {
            var grid = new Grid(4, 4);
            var cellTarget = new Cell(3, 0);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(2, 0));
            grid.AddCell(new Cell(3, 1));
            grid.AddCell(new Cell(0, 3));
            grid.AddCell(new Cell(2, 3));
            grid.AddCell(new Cell(3, 3));
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(1, 3));
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(2, 0),
                new Cell(3, 1),
                new Cell(0, 3),
                new Cell(2, 3),
                new Cell(3, 3)
            };
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(7, actualNeighbourCells.Count());
        }


        [Fact]
        public void AddCellIfDoesNotExistInLivingCells()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(1, 2));
            var expectedNeighbourCells = new List<Cell> { new Cell(1, 1), new Cell(1, 2) };
            var actualNeighbourCells = grid.GetLivingCells();

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(2, grid.GetLivingCells().Count());
        }

        [Fact]
        public void NotAddCelIfAlreadyExist()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(1, 1));

            Assert.Single(grid.GetLivingCells());
        }

        [Fact]
        public void ClearAllLivingCellsOfTheGrid()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(1, 1));
            grid.Clear();

            Assert.Empty(grid.GetLivingCells());
        }

        [Fact]
        public void GetAllEightNeighbourOfCell()
        {
            var grid = new Grid(4, 4);
            var cellTarget = new Cell(1, 1);
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(1, 0),
                new Cell(1, 2),
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2)
            };
            var actualNeighbourCells = grid.GetAllNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(8, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetAllEightNeighbourOfCellInACorner()
        {
            var grid = new Grid(4, 4);
            var cellTarget = new Cell(3, 0);
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(3, 1),
                new Cell(0, 3),
                new Cell(2, 3),
                new Cell(3, 3)
            };
            var actualNeighbourCells = grid.GetAllNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(8, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheDeadNeighboursOfCellInACorner()
        {
            var grid = new Grid(4, 4);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(1, 0));

            var expectedDeadNeighbours = new List<Cell>
            {
                new Cell(0, 2),
                new Cell(1, 2),
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2)
            };
            var actualDeadNeighboursOfCell = grid.GetDeadNeighboursOfLivingCell(cellTarget);

            expectedDeadNeighbours.Should().BeEquivalentTo(expectedDeadNeighbours);
            Assert.Equal(5, actualDeadNeighboursOfCell.Count());
        }


    }
}
