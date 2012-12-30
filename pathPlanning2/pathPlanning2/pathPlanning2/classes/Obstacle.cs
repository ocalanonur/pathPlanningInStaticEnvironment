using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace pathPlanning2.classes
{
    class Obstacle
    {
        public Game1 game;
        public Color color;
        public Position position;

        public Obstacle(Game1 game, Color color, Position position)
        {
            this.game = game;
            this.color = color;
            this.position = position;
        }
    }
}
