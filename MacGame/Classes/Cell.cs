using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife
{
    public class Cell
    {
        private int m_X;
        private int m_Y;
        private int m_Col;
        private int m_Row;
        private bool m_Alive;
        private Rectangle m_bounds;
        private Texture2D m_pixel; 
        private Texture2D m_dead; 
        private SpriteBatch m_spriteBatch;
        private GraphicsDevice m_graphics;


//        public Cell()
//        {
//            m_Alive = false;
//        }

        public Cell(int col, int row, GraphicsDevice graphics, SpriteBatch spriteBatch, Texture2D texture, Texture2D dead)
        {
            m_graphics = graphics;
            m_spriteBatch = spriteBatch;
            m_Col = col;
            m_Row = row;
            m_pixel = texture;
            m_dead = dead;
        }

        public Cell(int col, int row,int x,int y,int size,
                    GraphicsDevice graphics, SpriteBatch spriteBatch, Texture2D texture, Texture2D dead)
        {
            m_graphics = graphics;
            m_spriteBatch = spriteBatch;
            m_Col = col;
            m_Row = row;
            m_X = x;
            m_Y = y;
            m_bounds = new Rectangle(x,y,size,size);
            m_Alive = false;
            m_pixel = texture;
            m_dead = dead;
        }

        public bool IsAlive {
            get {
                return m_Alive;
            }
            set {
                m_Alive = value;
            }
        }

        public int X
        {
            get
            {
                return m_X;
            }
        }

        public int Y
        {
            get
            {
                return m_Y;
            }
        }

        public int Column
        {
            get
            {
                return m_Col;
            }
        }
        public int Row
        {
            get
            {
                return m_Row;
            }
        }

        public Rectangle Bounds
        {
            get
            {
                return m_bounds;
            }
        }

        public void Death()
        {
            m_Alive = false;
        }

        public void Birth()
        {
            m_Alive = true;
        }

        public void Alive()
        {
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_pixel, m_bounds, Color.White); 
            m_spriteBatch.End();
        }

        public void Dead()
        {
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_dead, m_bounds, Color.White); 
            m_spriteBatch.End();
        }
    }
}
