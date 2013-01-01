using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace pathPlanning2.classes
{
    class Position
    {
        public Vector2 leftUpCorner;
        public Vector2 size;
        public List<Position> neighborList = new List<Position>();

        public Position dijkstraParent = null;
        public float dijkstraDistance = float.MaxValue;
        public bool dijkstraCompleted = false;

        public Position(Vector2 leftUpCorner, Vector2 size)
        {
            this.leftUpCorner = leftUpCorner;
            this.size = size;
        }

        public bool Intersect(Position position)
        {
            double centerX1 = this.leftUpCorner.X + ((this.size.X) / 2);
            double centerY1 = this.leftUpCorner.Y + ((this.size.Y) / 2);
            double centerX2 = position.leftUpCorner.X + ((position.size.X) / 2);
            double centerY2 = position.leftUpCorner.Y + ((position.size.Y) / 2);
            if ((Math.Abs(centerX1 - centerX2) < (Math.Abs(this.size.X + position.size.X) / 2)) && ((Math.Abs(centerY1 - centerY2) < (Math.Abs(this.size.Y + position.size.Y) / 2))))
                return true;
            else
                return false;
        }
        
        /// <summary>
        /// Seçilmiş harita içerisinde herhangi bu pozisyona bir serbest bir yolun olup olmadığını hesaplar.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public bool isConnectable(Position position, Map map)
        {
            Position virtualPosition = new Position(this.leftUpCorner, this.size);
            Vector2 direction;
            bool XisSame = false;
            bool YisSame = false;
            while (true)
            {
                direction = position.leftUpCorner - virtualPosition.leftUpCorner;  // Yön belirlenir.
                direction.Normalize();
                virtualPosition.leftUpCorner += direction;
                if (float.IsNaN(virtualPosition.leftUpCorner.X) || float.IsNaN(virtualPosition.leftUpCorner.Y))
                    return false;
                foreach (Obstacle obs in map.obstacleList)
                {
                    if (virtualPosition.Intersect(obs.position))
                        return false;
                }
                if ((Math.Abs(virtualPosition.leftUpCorner.X - position.leftUpCorner.X) <= (Math.Abs(direction.X * 2))) && !XisSame )
                {
                    XisSame = true;
                    virtualPosition.leftUpCorner.X = position.leftUpCorner.X;
                }
                if ((Math.Abs(virtualPosition.leftUpCorner.Y - position.leftUpCorner.Y) <= (Math.Abs(direction.Y * 2))) && !YisSame )
                {
                    YisSame = true;
                    virtualPosition.leftUpCorner.Y = position.leftUpCorner.Y;
                }
                if (XisSame && YisSame)
                    return true;
            }
        }

        public int findNearestAndConnectablePositionInRoadmap(Roadmap roadmap,Map map)
        {
            float minLen = float.MaxValue;
            float len;
            int index = -1;
            for (int i = 0; i < roadmap.samplePositionList.Count; i++)
            {
                len = Vector2.Distance(this.leftUpCorner, roadmap.samplePositionList[i].leftUpCorner);
                if (len < minLen)
                {
                    if (this.isConnectable(roadmap.samplePositionList[i],map))
                    {
                        minLen = len;
                        index = i;
                    }
                }
            }
            return index;
        }

        public bool isSamePosition(Position position)
        {
            if (this.leftUpCorner == position.leftUpCorner)
                return true;
            return false;
        }

        public int findFarthestPositionIndexInNeighbor()
        {
            double currentLen;
            double maxLen = double.MinValue;
            int maxIndex = -1;
            for (int i = 0; i < neighborList.Count; i++)
            {
                currentLen = Vector2.Distance(this.leftUpCorner, neighborList[i].leftUpCorner);
                if (currentLen > maxLen)
                {
                    maxLen = currentLen;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public bool isOnObstacles(Map gameMap)
        {
            foreach (Obstacle obs in gameMap.obstacleList)
            {
                if (this.Intersect(obs.position))
                    return true;
            }
            return false;
        }
    }
}
