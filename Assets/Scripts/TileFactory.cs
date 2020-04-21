using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory
{
    private Dictionary<string, Tile> _tiles = new Dictionary<string, Tile>();
    private static TileFactory _instance = null;

    private TileFactory()
    {
        _tiles.Add("OutdoorsGround_0", new Tile() { 
            Name = "Grass_1",
            Weight = 7
        });
        _tiles.Add("OutdoorsGround_1", new Tile()
        {
            Name = "Grass_2",
            Weight = 7
        });
        _tiles.Add("OutdoorsGround_2", new Tile()
        {
            Name = "Grass_3",
            Weight = 7
        });
        _tiles.Add("OutdoorsGround_6", new Tile()
        {
            Name = "Road_1",
            Weight = 3
        });
        _tiles.Add("OutdoorsGround_7", new Tile()
        {
            Name = "Road_2",
            Weight = 3
        });
        _tiles.Add("OutdoorsGround_8", new Tile()
        {
            Name = "Road_3",
            Weight = 3
        });
        _tiles.Add("OutdoorsGround_9", new Tile()
        {
            Name = "Road_4",
            Weight = 3
        });
        _tiles.Add("OutdoorsGround_19", new Tile()
        {
            Name = "Road_5",
            Weight = 3
        });
        _tiles.Add("OutdoorsGround_13", new Tile()
        {
            Name = "Road_Edge_Top",
            Weight = 4
        });
        _tiles.Add("OutdoorsGround_16", new Tile()
        {
            Name = "Road_Edge_Bottom_Right",
            Weight = 5
        });
        _tiles.Add("OutdoorsGround_17", new Tile()
        {
            Name = "Road_Edge_Bottom_Left",
            Weight = 5
        });
        _tiles.Add("OutdoorsGround_18", new Tile()
        {
            Name = "Road_Edge_Left",
            Weight = 4
        });
        _tiles.Add("OutdoorsGround_20", new Tile()
        {
            Name = "Road_Edge_Right",
            Weight = 4
        });
        _tiles.Add("OutdoorsGround_23", new Tile()
        {
            Name = "Road_Edge_Top_Left",
            Weight = 5
        });
        _tiles.Add("OutdoorsGround_25", new Tile()
        {
            Name = "Road_Edge_Bottom",
            Weight = 4
        });
        _tiles.Add("OutdoorsGround_26", new Tile()
        {
            Name = "Road_Inside_Bottom_Right",
            Weight = 6
        });
        _tiles.Add("OutdoorsGround_31", new Tile()
        {
            Name = "Shore_Corner_Left",
            Weight = 15
        });
        _tiles.Add("OutdoorsGround_32", new Tile()
        {
            Name = "Shore_Bottom",
            Weight = 10
        });
        _tiles.Add("OutdoorsGround_33", new Tile()
        {
            Name = "Shore_Corner_Right",
            Weight = 15
        });
        _tiles.Add("OutdoorsGround_36", new Tile()
        {
            Name = "Shore_Left",
            Weight = 10
        });
        _tiles.Add("OutdoorsGround_42", new Tile()
        {
            Name = "Water",
            Weight = 100
        });
        _tiles.Add("Generic", new Tile()
        {
            Name = "Unknown",
            Weight = 20
        });
    }

    public static TileFactory GetInstance()
    {
        if(_instance == null)
        {
            _instance = new TileFactory();
        }
        return _instance;
    }

    public Tile GetTile(string tileName)
    {
        if (_tiles.ContainsKey(tileName))
        {
            return _tiles[tileName];
        }
        else
        {
            return _tiles["Generic"];
        }
    }
}
