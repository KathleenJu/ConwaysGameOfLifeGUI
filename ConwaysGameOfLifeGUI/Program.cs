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
            var renderer = new GuiRenderer(gameOfLife);

            Application.Run(renderer);
           
        }
    }
}
