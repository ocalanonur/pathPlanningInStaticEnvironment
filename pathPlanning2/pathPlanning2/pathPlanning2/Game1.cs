using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using pathPlanning2.classes;
using System.IO;

namespace pathPlanning2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region GameDefaults
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        #endregion

        #region PathPlanningClassVariables
        Map gameMap;
        Roadmap roadmap;
        //List<Agent> agentList;
        Texture2D obstacleTexture,goalPositionImageTexture;
        Agent agent1;
        MouseState mauseState;
        Position mausePosition;
        #endregion

        #region PathPlanningVariables
        string gameMapString = "Map61";
        int sampleSize = 100;
        int depth = 10;
        #endregion


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;//900GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;//600GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //agentList = new List<Agent>();
            gameMap = new Map(this, gameMapString);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            obstacleTexture = Content.Load<Texture2D>("obstacleImage");
            Texture2D tempTexture = Content.Load<Texture2D>("ball");
            goalPositionImageTexture = Content.Load<Texture2D>("goalPositionImage");
            Position agent1StartPosition = new Position(new Vector2(10, 10), new Vector2(tempTexture.Width, tempTexture.Height));
            Position agent1FinishPosition = new Position(new Vector2(800, 500), new Vector2(tempTexture.Width, tempTexture.Height));
            agent1 = new Agent(this, tempTexture, "Agent1", Color.DarkBlue, agent1StartPosition, agent1FinishPosition);
            roadmap = new Roadmap(gameMap, agent1, sampleSize, depth);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            else if (Keyboard.GetState().IsKeyDown(Keys.PrintScreen))
                screenShot();


            if (agent1.isMove)
            {
                agent1.move();
            }
            else
            {
                roadmap.clearDijikstraRecords();
                mauseState = Mouse.GetState();
                if (!agent1.startPositionLocated)
                {
                    // Baþlangýç konumu belirlenmediyse burada seçtirilecek.
                    if (mauseState.LeftButton == ButtonState.Pressed)
                    {
                        mausePosition = new Position(new Vector2(mauseState.X, mauseState.Y), new Vector2(agent1.startPosition.size.X, agent1.startPosition.size.Y));
                        if (mausePosition.isOnObstacles(gameMap))
                            return;
                        agent1.startPosition = mausePosition;
                        agent1.startPositionLocated = true;
                    }
                }
                else if (agent1.startPositionLocated && !agent1.goalPositionLocated)
                {
                    if (mauseState.RightButton == ButtonState.Pressed)
                    {
                        mausePosition = new Position(new Vector2(mauseState.X, mauseState.Y), new Vector2(agent1.startPosition.size.X, agent1.startPosition.size.Y));
                        if (mausePosition.isOnObstacles(gameMap))
                            return;
                        agent1.goalPosition = mausePosition;
                        agent1.goalPositionLocated = true;

                        agent1.position = new Position(agent1.startPosition.leftUpCorner, agent1.startPosition.size);
                        if (roadmap.findAgentsRoad() == true)
                            agent1.isMove = true;
                        else
                        {
                            agent1.startPositionLocated = false;
                            agent1.goalPositionLocated = false;
                        }
                    }
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.White);
            mauseState = Mouse.GetState();
            spriteBatch.Begin();
            
            // Drawing Obstacles
            gameMap.drawAllObstacles(spriteBatch, obstacleTexture);

            Texture2D blank = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });
            foreach (Position rec in roadmap.samplePositionList)
            {
                foreach (Position nb in rec.neighborList)
                {
                    float angle = (float)Math.Atan2(nb.leftUpCorner.Y - rec.leftUpCorner.Y, nb.leftUpCorner.X - rec.leftUpCorner.X);
                    float length = Vector2.Distance(rec.leftUpCorner, nb.leftUpCorner);
                    spriteBatch.Draw(blank, new Vector2(rec.leftUpCorner.X + 5, rec.leftUpCorner.Y + 5), null, Color.Black, angle, Vector2.Zero, new Vector2(length, (float)1), SpriteEffects.None, 0);
                }
                spriteBatch.Draw(Content.Load<Texture2D>("randomPosition"), rec.leftUpCorner, Color.LightBlue);
            }
            if (agent1.goalPositionLocated)
                spriteBatch.Draw(goalPositionImageTexture, agent1.goalPosition.leftUpCorner, Color.Green);
            if (agent1.isMove)
                spriteBatch.Draw(agent1.texture, agent1.position.leftUpCorner, agent1.color);
            else
            {
                if (!agent1.startPositionLocated)
                    spriteBatch.Draw(agent1.texture, new Vector2(mauseState.X, mauseState.Y), agent1.color);
                else
                    spriteBatch.Draw(goalPositionImageTexture, new Vector2(mauseState.X, mauseState.Y), Color.Green);
            }
            if (agent1.startPositionLocated)
                spriteBatch.Draw(goalPositionImageTexture, agent1.startPosition.leftUpCorner, Color.Gold);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void screenShot()
        {
            int w = GraphicsDevice.PresentationParameters.BackBufferWidth;
            int h = GraphicsDevice.PresentationParameters.BackBufferHeight;

            //force a frame to be drawn (otherwise back buffer is empty)
            Draw(new GameTime());

            //pull the picture from the buffer
            int[] backBuffer = new int[w * h];
            GraphicsDevice.GetBackBufferData(backBuffer);
            
            //copy into a texture
            Texture2D texture = new Texture2D(GraphicsDevice, w, h, false, GraphicsDevice.PresentationParameters.BackBufferFormat);
            texture.SetData(backBuffer);

            //save to disk
            Stream stream = File.OpenWrite(Guid.NewGuid().ToString() + ".png");
            texture.SaveAsPng(stream, w, h);
            stream.Close();
        }
    }
}
