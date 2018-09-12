using System.Collections.Generic;
using ConwaysGameOfLifeGUI;

namespace ConwaysGameOfLife.Tests
{
    public class Helper
    {
        public List<Cell> TransformGraphToCells(int[][] graph)
        {
            var cells = new List<Cell>();
            for (int rowIndex = 0; rowIndex < graph.Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < graph[rowIndex].Length; columnIndex++)
                {
                    if (graph[rowIndex][columnIndex] == 1)
                    {
                        cells.Add(new Cell(rowIndex, columnIndex));
                    }
                }
            }
            return cells;
        }
    }
}