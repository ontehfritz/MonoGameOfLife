using System;
using System.Collections.Generic;
using System.Text;
//using SdlDotNet;
//using SdlDotNet.Core;
//using SdlDotNet.Input;
//using SdlDotNet.Graphics;

using System.Drawing;

namespace GameOfLife
{
    class SDLRender
    {
        private const int width = 800;
        private const int height = 600;
        private bool quit = false;
        private bool start = false;
        //private Surface screen;
        private Cell [,] m_Cell;
        private GameGrid life;

        public SDLRender()
        {
            //Events.KeyboardDown += new EventHandler<KeyboardEventArgs>(KeyDown);
			//Events.Quit += new EventHandler<QuitEventArgs>(Quit);
			//Events.Tick += new EventHandler<TickEventArgs>( Run );

			//screen = Video.SetVideoMode(width, height,32, false, false, false, true, true );
//			m_Cell = new Cell[height/10-10, width/10];
//			int cols = 0;
//			int rows = 0;
//			
//			for (int row = 0; row < height/10-10; row++)
//			{
//				cols = 0;
//                m_Cell[row, 0] = new Cell(0,row, cols, rows,10,graphics.GraphicsDevice, spriteBatch);
//				
//				for (int col = 1; col < width/10; col++)
//				{
//					cols += 10/*replace with width*/ + 2;
//					
//                    m_Cell[row, col] = new Cell(col,row,cols,rows,10,graphics.GraphicsDevice, spriteBatch);
//					
//					//  m_Cell[row, col].X = cols + 20;
//					// m_Cell[row, col].Y = rows + 20;
//				}
//				rows += 10 + 2;
//			}
			//life = new GameGrid(width/10, height/10-10, m_Cell,);

			//Video.WindowCaption = "Game of Life";
			//Events.Run();
           
            

        }
		public void Start ()
		{
			//Events.Run();
		}

		//public void Run(object sender, TickEventArgs args)
        //{
//            while (!quit)
//            {
//				while(Events.Poll()){};  
          //    Render();
//
//
//            }
        //}

//        private void KeyDown(object s, KeyboardEventArgs e)
//        {
//            if (e.Key == Key.Escape)
//            {
//                Events.QuitApplication();
//            }
//            if (e.Key == Key.S)
//            {
//                start = !start;
//            }
//        }
//
//        private void Quit(object s, QuitEventArgs e)
//        {
//			Events.QuitApplication();
//        }
//
//        private void Render()
//        {
//            screen.Fill(
//                    Color.FromArgb(
//                        255,
//                        255,
//                        255));
//
//
//            for (int row = 0; row < height / 10-10; row++)
//            {
//                for (int col = 0; col < width/10; col++)
//                {
//                    if(life.RetrieveCell(col,row).IsAlive)
//                        screen.Fill(this.m_Cell[row, col].Bounds, Color.Black);
//                    else
//                        screen.Fill(this.m_Cell[row, col].Bounds, Color.Aqua);
//                }
//            }
//            
//            if (start)
//            {
//                life.Move();
//            }
//		
//            screen.Update();
//        }
    }
}
