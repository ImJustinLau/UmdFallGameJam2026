using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public GameObject TileObject { get; set; }
    public Vector3 WorldPosition { get; set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    // Adjacent tiles
    public Tile North { get; set; }
    public Tile South { get; set; }
    public Tile East { get; set; }
    public Tile West { get; set; }

    // Tile properties
    public string TileType { get; set; }

    public Tile(int x, int y)
    {
        X = x;
        Y = y;
        TileType = "Empty";
    }

}
