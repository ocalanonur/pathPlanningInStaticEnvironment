using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pathPlanning2.classes
{
    class Map
    {
        public Game1 game;
        public string name;
        public List<Obstacle> obstacleList = new List<Obstacle>();

        public Map(Game1 game, string name)
        {
            this.game = game;
            this.name = name;
            setMap(name);
        }

        public void setMap(string name)
        {
            Obstacle obstacle1;
            Position p;
            switch (name)
            {
                case "Map1":
                    p = new Position(new Vector2(80, 30), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.DarkRed, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(200, 400), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.DarkRed, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(500, 500), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.DarkRed, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(400, 150), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.DarkRed, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(400, 250), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.DarkRed, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(550, 350), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.DarkRed, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(150, 200), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.DarkRed, p);
                    obstacleList.Add(obstacle1);
                    break;
                case "Map2":
                    p = new Position(new Vector2(80, 80), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.DarkRed, p);
                    obstacleList.Add(obstacle1);
                    break;
                case "Map3":
                    p = new Position(new Vector2(150, 200), new Vector2(100, 60));
                    obstacle1 = new Obstacle(game, Color.Yellow, p);
                    obstacleList.Add(obstacle1);
                    break;
                case "Map4":
                    p = new Position(new Vector2(675, 20), new Vector2(10, 300));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(675, 450), new Vector2(10, 300));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(20, 375), new Vector2(585, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(750, 375), new Vector2(600, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    break;
                case "Map5":
                    p = new Position(new Vector2(0, 80), new Vector2(40, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(150, 80), new Vector2(1400, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(0, 200), new Vector2(500, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(600, 200), new Vector2(800, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(0, 320), new Vector2(10, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(150, 320), new Vector2(1000, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(50, 350), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(150, 400), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(250, 350), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(350, 400), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(450, 350), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(550, 400), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(650, 350), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(750, 400), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(850, 350), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(950, 400), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(1050, 350), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(1150, 400), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    p = new Position(new Vector2(1250, 350), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    break;
                case "Map6":
                    //Obstacle1
                    p = new Position(new Vector2(0, 80), new Vector2(120, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle2
                    p = new Position(new Vector2(120, 80), new Vector2(10, 100));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle3
                    p = new Position(new Vector2(80, 180), new Vector2(50, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle4
                    p = new Position(new Vector2(300, 80), new Vector2(10, 250));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle5
                    p = new Position(new Vector2(120, 330), new Vector2(190, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle6
                    p = new Position(new Vector2(450, 0), new Vector2(10, 150));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle7
                    p = new Position(new Vector2(450, 150), new Vector2(450, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle8
                    p = new Position(new Vector2(550, 150), new Vector2(10, 150));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle9
                    p = new Position(new Vector2(550, 300), new Vector2(200, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle10
                    p = new Position(new Vector2(425, 300), new Vector2(10, 200));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle11
                    p = new Position(new Vector2(600, 425), new Vector2(300, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle12
                    p = new Position(new Vector2(900, 425), new Vector2(10, 275));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle13
                    p = new Position(new Vector2(600, 700), new Vector2(310, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle14
                    p = new Position(new Vector2(600, 520), new Vector2(10, 180));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle15
                    p = new Position(new Vector2(600, 520), new Vector2(200, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle16
                    p = new Position(new Vector2(800, 520), new Vector2(10, 100));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle17
                    p = new Position(new Vector2(700, 620), new Vector2(110, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle18
                    p = new Position(new Vector2(1000, 80), new Vector2(10, 590));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle19
                    p = new Position(new Vector2(1000, 100), new Vector2(250, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle20
                    p = new Position(new Vector2(1150, 250), new Vector2(250, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle21
                    p = new Position(new Vector2(1000, 400), new Vector2(250, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle22
                    p = new Position(new Vector2(1150, 650), new Vector2(250, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle23
                    p = new Position(new Vector2(70, 700), new Vector2(100, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle24
                    p = new Position(new Vector2(100, 600), new Vector2(150, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    break;
                case "Map7":
                    //Obstacle1
                    p = new Position(new Vector2(50, 50), new Vector2(1250, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle2
                    p = new Position(new Vector2(1300, 50), new Vector2(10, 650));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle3
                    p = new Position(new Vector2(90, 700), new Vector2(1220, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle4
                    p = new Position(new Vector2(90, 120), new Vector2(10, 580));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);

                    //Obstacle5
                    p = new Position(new Vector2(90, 120), new Vector2(1150, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle6
                    p = new Position(new Vector2(1240, 120), new Vector2(10, 500));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle6
                    p = new Position(new Vector2(170, 620), new Vector2(1080, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle7
                    p = new Position(new Vector2(170, 200), new Vector2(10, 420));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);

                    //Obstacle8
                    p = new Position(new Vector2(170, 200), new Vector2(1000, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle9
                    p = new Position(new Vector2(1170, 200), new Vector2(10, 350));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle10
                    p = new Position(new Vector2(250, 550), new Vector2(930, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle11
                    p = new Position(new Vector2(250, 280), new Vector2(10, 270));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);

                    //Obstacle12
                    p = new Position(new Vector2(250, 280), new Vector2(850, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle13
                    p = new Position(new Vector2(1100, 280), new Vector2(10, 200));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle14
                    p = new Position(new Vector2(330, 480), new Vector2(780, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle15
                    p = new Position(new Vector2(330, 360), new Vector2(10, 120));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);

                    //Obstacle16
                    p = new Position(new Vector2(330, 360), new Vector2(700, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle17
                    p = new Position(new Vector2(1030, 360), new Vector2(10, 70));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    //Obstacle18
                    p = new Position(new Vector2(400, 430), new Vector2(640, 10));
                    obstacle1 = new Obstacle(game, Color.Red, p);
                    obstacleList.Add(obstacle1);
                    break;

            }
        }

        /// <summary>
        /// Bütün engelleri ekranda görüntüler. Spritebatch.Begin önceden yapılmalıdır.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch</param>
        /// <param name="obstacleTexture">Engel resmi</param>
        public void drawAllObstacles(SpriteBatch spriteBatch, Texture2D obstacleTexture)
        {
            // Drawing Obstacles
            foreach (Obstacle currentObstacle in this.obstacleList)
                spriteBatch.Draw(obstacleTexture, new Rectangle((int)currentObstacle.position.leftUpCorner.X, (int)currentObstacle.position.leftUpCorner.Y, (int)currentObstacle.position.size.X, (int)currentObstacle.position.size.Y), currentObstacle.color);
        }
    }
}
