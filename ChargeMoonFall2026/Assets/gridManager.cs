using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{
 
    
    public float TileSize = 1f;
    public float Spacing = 0.1f;
    public int Width { get; private set; }
    public int Height { get; private set; }
    
    [SerializeField] GameObject TilePrefab;

    public Tile[,] Tiles { get; private set; }

    public void GenerateTileGrid(int width, int height)
    {
        Width = width;
        Height = height;

        Tiles = new Tile[width, height];

        GenerateGrid();
        ConnectNeighbors();
        PositionTiles();
    }
    void Start()
    {
        GenerateTileGrid(20,10);
    }
    
    private void PositionTiles()
    {
        float distance = TileSize + Spacing;

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Vector3 position = new Vector3(x * distance, y * distance, 0);
                Tiles[x, y].WorldPosition =
                    position;
                Tiles[x, y].TileObject = Instantiate(
                    TilePrefab,
                    tile.position,
                    Quaternion.identity
                );
            }
        }
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Tiles[x, y] = new Tile(x, y);
                
            }
        }
    }

    private void ConnectNeighbors()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Tile tile = Tiles[x, y];

                // Connect adjacent tiles
                if (y + 1 < Height)
                    tile.North = Tiles[x, y + 1];

                if (y - 1 >= 0)
                    tile.South = Tiles[x, y - 1];

                if (x + 1 < Width)
                    tile.East = Tiles[x + 1, y];

                if (x - 1 >= 0)
                    tile.West = Tiles[x - 1, y];
            }
        }
    }
}
