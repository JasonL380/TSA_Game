// Name: Jason Leech
// Date: 12/15/2022
// Desc: Script to manage a global pathfinding graph that can be updated when needed

using System;
using UnityEngine;

namespace Utils
{
    public class PathfinderGraphManager : MonoBehaviour
    {
        [Tooltip("select all layers that contain objects which should be treated as walls")]
        public LayerMask wallLayers;

        public bool displayDebug = true;

        [Tooltip("The collider radius that should be used for pathfinding")]
        public float pathfinderSize;

        [Tooltip("The center of the pathfinding area")]
        public Vector2 boxCenter;

        [Tooltip("The size of the pathfinding area")]
        public Vector2 boxSize;

        [Tooltip(
            "The density of nodes in the pathfinding area, higher values will allow for more accurate pathfinding but will take longer to process")]
        public float nodeDensity;

        //The spacing between nodes in the graph
        public Vector2 gridSize = new Vector2();

        //the bottom left (negative, negative) corner of the pathfinding area
        public Vector2 gridStart = new Vector2();

        //stores 5 boolean values in the order right, down, left, up, isPoint
        public short[,] graph;

        public Vector2Int graphDimensions = new Vector2Int();

        //incremented every time this updates, used for telling pathfinders that they should update their path
        public int update = 0;
        
        private void Awake()
        {
            GenerateGraph();
        }

        private void FixedUpdate()
        {
            if (displayDebug)
            {
                DrawAll();
            }
        }

        void GenerateGraph()
        {
            //calculate the grid size and dimensions from nodeDensity
            gridSize = new Vector2(1 / nodeDensity, 1 / nodeDensity); //boxSize / nodeDensity;
            gridStart = boxCenter - (boxSize / 2);
            int sizeX = (int)(nodeDensity * boxSize.x);
            int sizeY = (int)(nodeDensity * boxSize.y);
            graphDimensions.x = sizeX;
            graphDimensions.y = sizeY;

            //initialize the graph array
            graph = new short[sizeX, sizeY];

            //fill entire walkable space with points
            for (int x = 0; x < sizeX; ++x)
            {
                for (int y = 0; y < sizeY; ++y)
                {
                    //the absolute position of this grid point
                    Vector2 position = (gridSize * new Vector2(x, y)) + gridStart;

                    //create a circle overlap with the same size as this object's collider to detect any nearby walls, aka determine if the object is able to exist at this position
                    Collider2D[] collision = Physics2D.OverlapCircleAll(position, pathfinderSize, wallLayers);
                    
                    //if the circle didn't collide with anything add a node here
                    if (collision.Length == 0)
                    {
                        graph[x, y] = 1;

                        //draw the point on screen if enabled
                        if (displayDebug)
                        {
                            //Debug.DrawLine(position, position - new Vector2(0, 0.1F), Color.red, 30);
                        }
                    }
                    else
                    {
                        int cost = DetermineCost(collision);
                        if (cost == -1)
                        {
                            graph[x, y] = 0;
                            //print("cost is -1");
                        }
                        else
                        {
                            graph[x, y] = (short) (cost << 8 | 1);
                            if (displayDebug)
                            {
                                //Debug.DrawLine(position, position - new Vector2(0, 0.1F), Color.green, 30);
                            }
                            print(graph[x,y]);
                        }
                    }
                }
            }

            //loop through the graph to fill in data about neighbors
            for (int x = 0; x < sizeX; ++x)
            {
                for (int y = 0; y < sizeY; ++y)
                {
                    //if there isn't a point here do nothing
                    if (graph[x, y] != 0)
                    {
                        //right
                        if (x + 1 < sizeX && (graph[x + 1, y] & 1) != 0)
                        {
                            graph[x, y] = Convert.ToInt16(1 << 4 | graph[x, y]);
                        }

                        //down
                        if (y - 1 > -1 && (graph[x, y - 1] & 1) != 0)
                        {
                            graph[x, y] = Convert.ToInt16(1 << 3 | graph[x, y]);
                        }

                        //left
                        if (x - 1 > -1 && (graph[x - 1, y] & 1) != 0)
                        {
                            graph[x, y] = Convert.ToInt16(1 << 2 | graph[x, y]);
                        }

                        //up
                        if (y + 1 < sizeY && (graph[x, y + 1] & 1) != 0)
                        {
                            graph[x, y] = Convert.ToInt16(1 << 1 | graph[x, y]);
                        }
                    }
                }
            }
        }
        
        //update all graph points inside the square defined by corner1 and corner2
        public void UpdateGraph(Vector2 corner1, Vector2 corner2)
        {
            Debug.DrawLine(corner1, new Vector2(corner1.x, corner2.y), Color.magenta);
            Debug.DrawLine(corner2, new Vector2(corner1.x, corner2.y), Color.magenta);
            Debug.DrawLine(corner2, new Vector2(corner2.x, corner1.y), Color.magenta);
            Debug.DrawLine(corner1, new Vector2(corner2.x, corner1.y), Color.magenta);
            Vector2Int gridCorner1 = actualToGrid(corner1) - new Vector2Int(2,  2);
            Vector2Int gridCorner2 = actualToGrid(corner2) + new Vector2Int(2,  2);
            print("updating " + gridCorner1 + ", " + gridCorner2);
            //fill all walkable space within the square with points
            for (int x = gridCorner1.x; x < gridCorner2.x; ++x)
            {
                for (int y = gridCorner1.y; y < gridCorner2.y; ++y)
                {
                    //the absolute position of this grid point
                    Vector2 position = (gridSize * new Vector2(x, y)) + gridStart;

                    //create a circle overlap with the same size as this object's collider to detect any nearby walls, aka determine if the object is able to exist at this position
                    Collider2D[] collision = Physics2D.OverlapCircleAll(position, pathfinderSize, wallLayers);

                    //if the circle didn't collide with anything add a node here
                    if (collision == null)
                    {
                        graph[x, y] = 1;

                        //draw the point on screen if enabled
                        if (displayDebug)
                        {
                            //Debug.DrawLine(position, position - new Vector2(0, 0.1F), Color.red);
                        }
                    }
                    else
                    {
                        int cost = DetermineCost(collision);
                        if (cost == -1)
                        {
                            graph[x, y] = 0;
                        }
                        else
                        {
                            graph[x, y] = (short) (cost << 8 | 1);
                            
                            print("Graph Manager: Found a obstacle at " + x + ", " + y + "  graph data is " + graph[x, y] + " "+ (graph[x, y] & 0x1));
                        }
                    }
                }
            }
            
            //add data about neighbors
            for (int x = gridCorner1.x - 1; x < gridCorner2.x + 1; ++x)
            {
                for (int y = gridCorner1.y - 1; y < gridCorner2.y + 1; ++y)
                {
                    //if there isn't a point here do nothing
                    if ((graph[x, y] & 0x1) == 1)
                    {
                        //right
                        if (x + 1 < graphDimensions.x && (graph[x + 1, y] & 0x1) == 1)
                        {
                            graph[x, y] = Convert.ToInt16(1 << 4 | graph[x, y]);
                        }

                        //down
                        if (y - 1 > -1 && (graph[x, y - 1] & 0x1) == 1)
                        {
                            graph[x, y] = Convert.ToInt16(1 << 3 | graph[x, y]);
                        }

                        //left
                        if (x - 1 > -1 && (graph[x - 1, y] & 0x1) == 1)
                        {
                            graph[x, y] = Convert.ToInt16(1 << 2 | graph[x, y]);
                        }

                        //up
                        if (y + 1 < graphDimensions.y && (graph[x, y + 1] & 0x1) == 1)
                        {
                            graph[x, y] = Convert.ToInt16(1 << 1 | graph[x, y]);
                        }
                    }
                }
            }

            //increment update to inform pathfinders that the graph has changed
            ++update;
            
            if (displayDebug)
            {
                DrawAll();
            }
        }

        void DrawAll()
        {
            for (int x = 0; x < graphDimensions.x; ++x)
            {
                for (int y = 0; y < graphDimensions.y; ++y)
                {

                    if (graph[x, y] >> 8 > 1)
                    {
                        Vector2 position = (gridSize * new Vector2(x, y)) + gridStart;
                        Debug.DrawLine(position, position - new Vector2(0, 0.1F), Color.green);
                    }
                    else if (graph[x, y] != 0)
                    {
                        Vector2 position = (gridSize * new Vector2(x, y)) + gridStart;
                        Debug.DrawLine(position, position - new Vector2(0, 0.1F), Color.red);
                    }
                }
            }
        }

        public Vector2 gridToActual(Vector2 gridCoord)
        {
            return (gridSize * gridCoord) + gridStart;
        }

        public Vector2Int actualToGrid(Vector2 actual)
        {
            //print(actual);
            Vector2 grid = (actual - (boxCenter - (boxSize / 2))) / gridSize;
            //print(grid + ", " + gridSize);
            grid.x = Math.Min(Math.Max(grid.x, 0), graphDimensions.x - 1);
            grid.y = Math.Min(Math.Max(grid.y, 0), graphDimensions.y - 1);
            return new Vector2Int((int) grid.x, (int) grid.y);
        }

        
        //determine the cost of a node given objects that it intersects
        //returns 1-255 for a path that can be passed
        //returns -1 if path cannot be passed
        int DetermineCost(Collider2D[] objects)
        {
            int cost = 1;
            for (int i = 0; i < objects.Length; ++i)
            {
                //calculate the cost for objects[i]
                GameObject obj = objects[i].gameObject;
                Health health = obj.GetComponent<Health>();
                if (health == null)
                {
                    print("no health found for " + obj.name);
                    return -1;
                }
                else
                {
                    cost += health.maxHealth;
                }
            }


            return Math.Min(cost, 255);
        }
    }
}