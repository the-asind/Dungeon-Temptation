using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap, wallTilemap, objectTilemap;

    [SerializeField] private TileBase floorTile, wallTop, wallSideRight;

    [SerializeField] private TileBase wallBottom,
        wallFull,
        wallInnerCornerDownLeft,
        wallInnerCornerDownRight,
        wallSideLeft,
        wallDiagonalCornerDownRight,
        wallDiagonalCornerDownLeft,
        wallDiagonalCornerUpRight,
        wallDiagonalCornerUpLeft;

    [SerializeField] private TileBase chests;
    
    public void SetFloorTiles(HashSet<Vector2Int> floorPositions)
    {
        SetTiles(floorPositions, floorTilemap, floorTile);
    }

    private void SetTiles(HashSet<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions) SetSingleTile(tilemap, tile, position);
    }

    internal void SetSingleBasicWall(Vector2Int position, string binaryType)
    {
        var typeAsByte = Convert.ToByte(binaryType, 2);
        TileBase tile = null;
        if (WallTypesHelper.WallTop.Contains(typeAsByte))
            tile = wallTop;
        else if (WallTypesHelper.WallSideRight.Contains(typeAsByte))
            tile = wallSideRight;
        else if (WallTypesHelper.WallSideLeft.Contains(typeAsByte))
            tile = wallSideLeft;
        else if (WallTypesHelper.WallBottom.Contains(typeAsByte))
            tile = wallBottom;
        else if (WallTypesHelper.WallFull.Contains(typeAsByte)) tile = wallFull;

        if (tile != null)
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
    }

    internal void SetSingleCornerWall(Vector2Int position, string binaryType)
    {
        var typeAsByte = Convert.ToByte(binaryType, 2);
        TileBase tile = null;

        if (WallTypesHelper.WallInnerCornerDownLeft.Contains(typeAsByte))
            tile = wallInnerCornerDownLeft;
        else if (WallTypesHelper.WallInnerCornerDownRight.Contains(typeAsByte))
            tile = wallInnerCornerDownRight;
        else if (WallTypesHelper.WallDiagonalCornerDownLeft.Contains(typeAsByte))
            tile = wallDiagonalCornerDownLeft;
        else if (WallTypesHelper.WallDiagonalCornerDownRight.Contains(typeAsByte))
            tile = wallDiagonalCornerDownRight;
        else if (WallTypesHelper.WallDiagonalCornerUpRight.Contains(typeAsByte))
            tile = wallDiagonalCornerUpRight;
        else if (WallTypesHelper.WallDiagonalCornerUpLeft.Contains(typeAsByte))
            tile = wallDiagonalCornerUpLeft;
        else if (WallTypesHelper.WallFullEightDirections.Contains(typeAsByte))
            tile = wallFull;
        else if (WallTypesHelper.WallBottomEightDirections.Contains(typeAsByte)) tile = wallBottom;

        if (tile != null)
            SetSingleTile(wallTilemap, tile, position);
    }
}