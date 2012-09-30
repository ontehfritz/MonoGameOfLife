using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace GameOfLife
{
    public class GameGrid
    {
        private int m_Width;
        private int m_Height;
        private Cell [,] m_Grid;
        private List<Cell> cells;
        private SpriteBatch m_spriteBatch;
        private GraphicsDevice m_graphics;
        private Texture2D texture;
        private Texture2D dead; 
        
        public GameGrid(int w, int h,Cell [,] grid, 
                        GraphicsDevice graphics, 
                        SpriteBatch spriteBatch,
                        MacGame game)
        {
            m_spriteBatch = spriteBatch;
            m_graphics = graphics;
            m_Width = w;
            m_Height = h;
            m_Grid = grid;  
            texture = game.Content.Load<Texture2D>("alive");
            dead = game.Content.Load<Texture2D>("dead");
        }
        public int Width
        {
            get
            {
                return m_Width;
            }
        }
        public int Height
        {
            get
            {
                return m_Height;
            }
        }
      
        public int CheckPersonalSpace(int x, int y)
        {
            int neighbours = 0;

            if ((x - 1) >= 0 && (y - 1) >= 0)
            {
                if (this.RetrieveCell(x - 1, y - 1).IsAlive)
                    ++neighbours;
            }

            if ((y - 1) >= 0)
            {
                if (this.RetrieveCell(x, y - 1).IsAlive)
                    ++neighbours;
            }

            if ((x + 1) < m_Width && (y - 1) >= 0)
            {
                if (this.RetrieveCell(x + 1, y - 1).IsAlive)
                    ++neighbours;
            }

            if ((x - 1) >= 0)
            {
                if (this.RetrieveCell(x - 1, y).IsAlive)
                    ++neighbours;
            }
            if ((x + 1) < m_Width)
            {
                if (this.RetrieveCell(x + 1, y).IsAlive)
                    ++neighbours;
            }
            if ((x - 1) >= 0 && (y + 1) < m_Height)
            {
                if (this.RetrieveCell(x - 1, y + 1).IsAlive)
                    ++neighbours;
            }

            if ((y + 1) < m_Height)
            {
                if (this.RetrieveCell(x, y + 1).IsAlive)
                    ++neighbours;
            }

            if ((x + 1) < m_Width && (y + 1) < m_Height)
            {
                if (this.RetrieveCell(x + 1, y + 1).IsAlive)
                    ++neighbours;
            }

            return neighbours;

        }

        public Cell RetrieveCell(int x, int y)
        {
            return m_Grid[y,x];
        }

        public bool IsThereLife
        {
            get
            {
                for (int row = 0; row < this.Height; row++)
                {
                    for (int col = 0; col < this.Width; col++)
                    {
                        if(RetrieveCell(row, col).IsAlive)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public void Move()
        {
            cells = new List<Cell>();
            //CheckPersonalSpace(0, 3000);
            for (int row = 0; row < m_Height; row++)
            {
                for (int col = 0; col < m_Width; col++)
                {
                   int neighbours = CheckPersonalSpace(col, row);
                   
                   if (neighbours < 2)
                    {
                        if (RetrieveCell(col, row).IsAlive)
                        {
                            Cell temp = new Cell(col, row, m_graphics, m_spriteBatch,texture,dead);
                            cells.Add(temp);
                        }
                    }
                    else if (neighbours == 3)
                    {
                        if (!RetrieveCell(col, row).IsAlive)
                        {
                            Cell temp = new Cell(col, row, m_graphics, m_spriteBatch, texture,dead);
                            temp.Birth();
                            cells.Add(temp);
                        }
                    }
                    else if (neighbours > 3)
                    {
                        if (RetrieveCell(col, row).IsAlive)
                        {
                            Cell temp = new Cell(col, row, m_graphics, m_spriteBatch, texture,dead);
                            cells.Add(temp);
                        }
                    }
                    
                }
            }

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].IsAlive)
                    m_Grid[cells[i].Row, cells[i].Column].Birth();
                else
                    m_Grid[cells[i].Row, cells[i].Column].Death();
            }

            cells.Clear();
        }
    }
}
