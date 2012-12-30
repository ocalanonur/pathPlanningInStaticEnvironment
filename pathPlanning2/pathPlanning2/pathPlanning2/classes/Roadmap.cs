using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pathPlanning2.classes
{
    class Roadmap
    {
        private Map map;
        private Agent agent;
        private Random rand = new Random();
        public List<Position> samplePositionList = new List<Position>();
        public int depth = 10;

        public Roadmap(Map map, Agent agent, int numberOfSample, int depth)
        {
            this.map = map;
            this.agent = agent;
            this.depth = depth;
            setSamplePositionList(numberOfSample);
            connectPositions();
            //int roadMapStartIndex = agent.position.findNearestAndConnectablePositionInRoadmap(this, map);
            //int roadMapGoalIndex = agent.goalPosition.findNearestAndConnectablePositionInRoadmap(this, map);
            //if (roadMapStartIndex != -1 && roadMapGoalIndex != -1)
            //{
            //    connectPositions();
            //    findMinimumPathOnGraphWithDijikstra(roadMapStartIndex, roadMapGoalIndex);
            //}
        }

        public bool findAgentsRoad()
        {
            int roadMapStartIndex = agent.position.findNearestAndConnectablePositionInRoadmap(this, map);
            int roadMapGoalIndex = agent.goalPosition.findNearestAndConnectablePositionInRoadmap(this, map);
            if (roadMapStartIndex != -1 && roadMapGoalIndex != -1)
            {
                findMinimumPathOnGraphWithDijikstra(roadMapStartIndex, roadMapGoalIndex);
                if (agent.stations.Count > 1)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private void findMinimumPathOnGraphWithDijikstra(int roadMapStartIndex, int roadMapGoalIndex)
        {
            List<Position> dijikstraSortedLocations = new List<Position>();

            Position position = samplePositionList[roadMapGoalIndex];
            position.dijkstraDistance = 0;
            position.dijkstraParent = agent.goalPosition;
            dijikstraSortedLocations.Add(position);
            agent.position.dijkstraParent = samplePositionList[roadMapStartIndex];

            while (dijikstraSortedLocations.Count > 0)
            {
                dijikstraSortedLocations.Sort(
                    delegate(Position p1, Position p2)
                    {
                        return p1.dijkstraDistance.CompareTo(p2.dijkstraDistance);
                    }
                );
                Position currentPosition = dijikstraSortedLocations[0];
                foreach (Position p in currentPosition.neighborList)
                {
                    float len = Vector2.Distance(p.leftUpCorner, currentPosition.leftUpCorner);
                    if ((!p.dijkstraCompleted) && (currentPosition.dijkstraDistance + len < p.dijkstraDistance))
                    {
                        p.dijkstraDistance = currentPosition.dijkstraDistance + len;
                        p.dijkstraParent = currentPosition;
                        dijikstraSortedLocations.Add(p);
                    }
                }
                currentPosition.dijkstraCompleted = true;
                dijikstraSortedLocations.RemoveAt(0);
            }

            while (agent.position.dijkstraParent != null)
            {
                //agent.stations.Enqueue(agent.position.dijkstraParent);
                agent.stations.Enqueue(new Position(agent.position.dijkstraParent.leftUpCorner, agent.position.dijkstraParent.size));
                agent.position.dijkstraParent= agent.position.dijkstraParent.dijkstraParent;
            }
            
        }

        private void connectPositions()
        {
            //foreach (Position p1 in samplePositionList)
            //{
            //    foreach (Position p2 in samplePositionList)
            //    {
            //        if (p1 == p2)   // Kendini kendine bağlamaması için...
            //            continue;
            //        else
            //        {
            //            // İki pozisyonun bağlanabilmesi için arada engel olmaması gerekir. isConnectable true dönmesi gerekir.
            //            if (p1.isConnectable(p2, map))
            //            {
            //                //Burada iki pozisyon arasında engel yoktur ve bağlanabilir.
            //                //if (!p1.neighborList.Contains(p2))
            //                //    p1.neighborList.Add(p2);
            //                //if (!p2.neighborList.Contains(p1))
            //                p1.neighborList.Add(p2);
            //            }
            //        }
            //    }
            //}
            int neighborCount;

            foreach (Position p1 in samplePositionList)
            {
                neighborCount = 0;
                foreach (Position p2 in samplePositionList)
                {
                    if (p1 == p2)   // Kendini kendine bağlamaması için...
                        continue;
                    if (neighborCount < depth)
                    {
                        if (p1.isConnectable(p2, map))
                        {
                            p1.neighborList.Add(p2);
                            neighborCount++;
                        }
                    }
                    else
                    {
                        int fi = p1.findFarthestPositionIndexInNeighbor();
                        double lenP1 = Vector2.Distance(p1.leftUpCorner, p1.neighborList[fi].leftUpCorner);
                        double lenP2 = Vector2.Distance(p1.leftUpCorner, p2.leftUpCorner);
                        if ((lenP1 > lenP2) && (p1.isConnectable(p2,map)))
                        {
                            p1.neighborList.RemoveAt(fi);
                            p1.neighborList.Add(p2);
                        }
                    }
                }
            }
        }

        private void setSamplePositionList(int numberOfSample)
        {
            //for (int i = 0; i < numberOfSample; i++)
            //    samplePositionList.Add(getFreePosition());
            for (int i = 0; i < numberOfSample; i++)
            {
                Position p = getFreePosition();
                samplePositionList.Add(p);
            }
        }

        private Position getFreePosition()
        {
            int displayWidth = agent.game.graphics.PreferredBackBufferWidth;
            int displayHeight = agent.game.graphics.PreferredBackBufferHeight;

            bool continueSearch = true;
            Position position;
            do
            {
                position = new Position(new Vector2(rand.Next(0, displayWidth - agent.texture.Width), rand.Next(0, displayHeight - agent.texture.Height)), new Vector2(agent.texture.Width, agent.texture.Height));
                continueSearch = false;
                foreach (Obstacle obs in map.obstacleList)
                {
                    if (position.Intersect(obs.position))
                    {
                        continueSearch = true;
                        break;
                    }
                }
            } while (continueSearch);
            return position;
        }

        public void clearDijikstraRecords()
        {
            foreach (Position p in this.samplePositionList)
            {
                p.dijkstraCompleted = false;
                p.dijkstraDistance = float.MaxValue;
                p.dijkstraParent = null;
            }
            agent.stations.Clear();
        }
    }
}
