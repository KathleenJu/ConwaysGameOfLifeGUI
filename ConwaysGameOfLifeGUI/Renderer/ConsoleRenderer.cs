using System;

namespace ConwaysGameOfLifeGUI.Renderer
{
    public class ConsoleRenderer: IRenderer
    {
        private string _title;
        private int _generationNumber;
        private int _numberOfLivingCells;

        public void SetTitle(string title)
        {
            _title = title;
        }

        public int GetGridWidth()
        {
            Console.WriteLine("Set width of Grid: ");
            var gridWidth = int.Parse(Console.ReadLine());
            return gridWidth;
        }

        public int GetGridHeight()
        {
            Console.WriteLine("Set height of Grid: ");
            var gridWidth = int.Parse(Console.ReadLine());
            return gridWidth;
        }

        public void SetGenerationNumber(int generation)
        {
            _generationNumber = generation;
        }

        public void SetNumberOfLivingCells(int noOfLivingCells)
        {
            _numberOfLivingCells = noOfLivingCells;
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void SetGrid(Grid grid)
        {
            throw new NotImplementedException();
        }
    }
}
