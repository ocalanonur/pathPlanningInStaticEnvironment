using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pathPlanning2.classes
{
    class Agent
    {
        public string name;
        public Game1 game;
        public Texture2D texture;
        public Color color;
        public Position position;
        public Position startPosition;
        public Position goalPosition;
        public bool isMove = false;

        public bool startPositionLocated = false;
        public bool goalPositionLocated = false;

        public Vector2 direction;
        public Queue<Position> stations = new Queue<Position>();

        private float speed = 2;

        public Agent(Game1 game, Texture2D texture, String name, Color color, Position startPosition, Position goalPosition)
        {
            this.game = game;
            this.texture = texture;
            this.name = name;
            this.color = color;
            this.startPosition = startPosition;
            this.goalPosition = goalPosition;
            this.speed = 2;
        }

        private void setDirection()
        {
            Vector2 v = stations.ElementAt(0).leftUpCorner - this.position.leftUpCorner;
            v.Normalize();
            direction = v;
        }

        public void move()
        {
            if (position.isSamePosition(goalPosition))
            {
                System.Threading.Thread.Sleep(2000);
                this.startPositionLocated = false;
                this.goalPositionLocated = false;
                isMove = false;
                return;
            }
            if (stations.Count != 0)
            {
                setDirection();
                this.position.leftUpCorner += direction * speed;
                if ((Math.Abs(position.leftUpCorner.X - stations.ElementAt(0).leftUpCorner.X) <= (Math.Abs(direction.X * speed)) && (Math.Abs(position.leftUpCorner.Y - stations.ElementAt(0).leftUpCorner.Y) <= (Math.Abs(direction.Y * speed)))))
                {
                    position = stations.ElementAt(0);
                    stations.Dequeue();
                }
            }
        }
    }
}
