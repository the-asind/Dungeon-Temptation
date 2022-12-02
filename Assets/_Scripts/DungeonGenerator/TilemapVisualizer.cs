using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap, wallTilemap, objectTilemap;

    [SerializeField] private TileBase 
        floorTile, 
        wallTop, 
        wallCenter,
        wallSideRight, 
        wallBottom,
        wallFull,
        wallInnerCornerDownLeft,
        wallInnerCornerDownRight,
        wallSideLeft,
        wallDiagonalCornerDownRight,
        wallDiagonalCornerDownLeft,
        wallDiagonalCornerUpRight,
        wallDiagonalCornerUpLeft;

    [SerializeField] private TileBase chestTile;
    
    public void SetFloorTiles(HashSet<Vector2Int> floorPositions)
    {
        SetTiles(floorPositions, floorTilemap, floorTile);

        var set2 = new HashSet<Vector2Int>();
        //alpha-like generating chests
        var r = new Random();
        foreach(var dinoToRemove in floorPositions
                    .OrderBy(x => r.Next())
                    .Take(45))
        {
            set2.Add(dinoToRemove);
        }
        
        SetTiles(GenerateChests(set2), objectTilemap, chestTile);
    }

    private HashSet<Vector2Int> GenerateChests(HashSet<Vector2Int> floorPositions)
    {
        
        return floorPositions;
    }

    private void SetTiles(HashSet<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions) SetSingleTile(tilemap, tile, position);
    }

    internal void SetSingleBasicWall(Vector2Int position, string binaryType)
    {
        var typeAsByte = Convert.ToByte(binaryType, 2);
        TileBase tile = null;
        if (WallHashType.WallTop.Contains(typeAsByte))
            tile = wallTop;
        else if (WallHashType.WallCenter.Contains(typeAsByte))
            tile = wallCenter;
        else if (WallHashType.WallSideRight.Contains(typeAsByte))
            tile = wallSideRight;
        else if (WallHashType.WallSideLeft.Contains(typeAsByte))
            tile = wallSideLeft;
        else if (WallHashType.WallBottom.Contains(typeAsByte))
            tile = wallBottom;
        else if (WallHashType.WallFull.Contains(typeAsByte)) tile = wallFull;

        if (tile)
            SetSingleTile(wallTilemap, tile, position);
    }

    private static void SetSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        objectTilemap.ClearAllTiles();
    }

    //https://stackoverflow.com/questions/74549502/
    internal void SetSingleCornerWall(Vector2Int position, string binaryType)
    {
        var typeAsByte = Convert.ToByte(binaryType, 2);
        TileBase tile = null;

        if (WallHashType.WallInnerCornerDownLeft.Contains(typeAsByte))
            tile = wallInnerCornerDownLeft;
        else if (WallHashType.WallInnerCornerDownRight.Contains(typeAsByte))
            tile = wallInnerCornerDownRight;
        else if (WallHashType.WallDiagonalCornerDownLeft.Contains(typeAsByte))
            tile = wallDiagonalCornerDownLeft;
        else if (WallHashType.WallDiagonalCornerDownRight.Contains(typeAsByte))
            tile = wallDiagonalCornerDownRight;
        else if (WallHashType.WallDiagonalCornerUpRight.Contains(typeAsByte))
            tile = wallDiagonalCornerUpRight;
        else if (WallHashType.WallDiagonalCornerUpLeft.Contains(typeAsByte))
            tile = wallDiagonalCornerUpLeft;
        else if (WallHashType.WallFullEightDirections.Contains(typeAsByte))
            tile = wallFull;
        else if (WallHashType.WallBottomEightDirections.Contains(typeAsByte)) tile = wallBottom;

        if (tile)
            SetSingleTile(wallTilemap, tile, position);
    }
}