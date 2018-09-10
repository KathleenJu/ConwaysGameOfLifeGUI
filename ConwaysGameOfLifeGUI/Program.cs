using System;
using System.Windows.Forms;
using ConwaysGameOfLifeGUI.Renderer;

namespace ConwaysGameOfLifeGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var gameOfLife = new GameOfLife();
            var gameEngine = new GameEngine(gameOfLife);
            var renderer = new GuiRenderer(gameEngine);

            Application.Run(renderer);
           
        }
    }
}
