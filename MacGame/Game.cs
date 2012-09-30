using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace GameOfLife
{
    public class MacGame : Game {

        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public GameGrid grid;
        public Cell [,] m_Cell;
        private Texture2D mouse; 
        int ticks;

        public MacGame() {
            graphics = new GraphicsDeviceManager (this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;   
            //IsFixedTimeStep = true;
        }

        protected override void Initialize () {
            base.Initialize();
            ticks = 0;
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            int width = graphics.PreferredBackBufferWidth;
            int height = graphics.PreferredBackBufferHeight;
            Texture2D texture = this.Content.Load<Texture2D>("alive");
            Texture2D dead = this.Content.Load<Texture2D>("dead");
            mouse = this.Content.Load<Texture2D>("mouse-pointer");

            m_Cell = new Cell[height/10-10, width/10];

            int cols = 0;
            int rows = 0;
            
            for (int row = 0; row < height/10-10; row++)
            {
                cols = 0;
                m_Cell[row, 0] = new Cell(0,row, cols, rows,10,graphics.GraphicsDevice, spriteBatch, texture, dead);
                //m_Cell[row, 0].IsAlive = true;
                
                for (int col = 1; col < width/10; col++)
                {
                    cols += 10/*replace with width*/ + 2;
                    
                    m_Cell[row, col] = new Cell(col,row,cols,rows,10,graphics.GraphicsDevice, spriteBatch, texture, dead);
                    if(col % 5 == 0)
                        m_Cell[row, col].IsAlive = true;  
                    else
                        m_Cell[row, col].IsAlive = false;
                    //  m_Cell[row, col].X = cols + 20;
                    // m_Cell[row, col].Y = rows + 20;
                }
                rows += 10 + 2;
            }


            grid = new GameGrid(width/10, height/10-10, m_Cell, 
                                graphics.GraphicsDevice, spriteBatch, this);
        }

        //protected override void Draw(GameTime gameTime) {
        //    graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
        //}

        protected override void Update (GameTime gameTime) {
         
            if (Keyboard.GetState (PlayerIndex.One).IsKeyDown (Keys.Escape)) {
                Exit ();    
            }
            if (ticks == 100) {
                grid.Move ();
                ticks = 0;
            }

            ticks++;
            // TODO: Add your update logic here 
            //screenManager.Update(gameTime);
            base.Update (gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw (GameTime gameTime){
            graphics.GraphicsDevice.Clear (Color.Black);
            int width = graphics.PreferredBackBufferWidth;
            int height = graphics.PreferredBackBufferHeight;

            spriteBatch.Begin();

            for (int row = 0; row < height / 10-10; row++)
            {
                for (int col = 0; col < width/10; col++)
                {
                    if(grid.RetrieveCell(col,row).IsAlive)
                        this.m_Cell[row, col].Alive();
                    else
                        this.m_Cell[row, col].Dead();
                }
            }

            spriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White); 

            spriteBatch.End();

            base.Draw (gameTime);
        }
    }
}
