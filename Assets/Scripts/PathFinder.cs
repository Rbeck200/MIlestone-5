using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinder
{
    public static TilePath DiscoverPath(Tilemap map, Vector3Int start, Vector3Int end)
    {
        //you will return this path to the user.  It should be the shortest path between
        //the start and end vertices 
        TilePath discoveredPath = new TilePath();

        //TileFactory is how you get information on tiles that exist at a particular vector's
        //coordinates
        TileFactory tileFactory = TileFactory.GetInstance();

        //This is the priority queue of paths that you will use in your implementation of
        //Dijkstra's algorithm
        PriortyQueue<TilePath> pathQueue = new PriortyQueue<TilePath>();

        //You can slightly speed up your algorithm by remembering previously visited tiles.
        //This isn't strictly necessary.
        Dictionary<Vector3Int, int> discoveredTiles = new Dictionary<Vector3Int, int>();

        //quick sanity check
        if(map == null || start == null || end == null)
        {
            return discoveredPath;
        }

        //This is how you get tile information for a particular map location
        //This gets the Unity tile, which contains a coordinate (.Position)
        var startingMapLocation = map.GetTile(start);

        //And this converts the Unity tile into an object model that tracks the
        //cost to visit the tile.
        var startingTile = tileFactory.GetTile(startingMapLocation.name);
        startingTile.Position = start;

        //Any discovered path must start at the origin!
        discoveredPath.AddTileToPath(startingTile);

        //This adds the starting tile to the PQ and we start off from there...
        pathQueue.Enqueue(discoveredPath);
        bool found = false;
        while(found == false && pathQueue.IsEmpty() == false){

            //Get the next path from the queue
            TilePath Path = new TilePath(pathQueue.GetFirst());
            pathQueue.Dequeue();

            //Get newest added tile to process
            Tile Tile = new Tile(Path.GetMostRecentTile());
            Vector3Int Position = new Vector3Int(Tile.Position.x, Tile.Position.y, Tile.Position.z);

            //Add neighbors of newest tile to list for processing
            List<Vector3Int> adjacentTiles = new List<Vector3Int>();
            adjacentTiles.Add(new Vector3Int(Position.x, Position.y + 1, Position.z));
            adjacentTiles.Add(new Vector3Int(Position.x, Position.y - 1, Position.z));
            adjacentTiles.Add(new Vector3Int(Position.x + 1, Position.y, Position.z));
            adjacentTiles.Add(new Vector3Int(Position.x - 1, Position.y, Position.z));

            //For each loop processes each neighboring tile in list
            foreach(Vector3Int tile in adjacentTiles){

                //Creates new path with current path as basis
                TilePath newPath = new TilePath(Path);
                Vector3Int newPosition = new Vector3Int(tile.x, tile.y, tile.z);

                //Grabs the data from our tile sprite in our tilemap
                var tileData = map.GetTile(newPosition);
                if (tileData == null)
                    continue;

                //Associates the data with an actual tile 
                var newTile = tileFactory.GetTile(tileData.name);
                newTile.Position = newPosition;

                //If at end add tile and finish up
                if(newTile.Position == end){
                    newPath.AddTileToPath(newTile);
                    discoveredPath = newPath;
                    found = true;
                    break;
                }
                //If tile isn't end but hasnt been visited yet
                else if (discoveredTiles.ContainsKey(newPosition) == false){
                    newPath.AddTileToPath(newTile);
                    pathQueue.Enqueue(newPath);
                    discoveredTiles.Add(newPosition, 1);
                }
            }
        }
        return discoveredPath;
    }
}
