using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Debug = UnityEngine.Debug;

namespace _Scripts.DungeonGenerator
{
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

        [SerializeField] private TileBase
            chestTile,
            ladderTile;

        public void SetFloorTiles(HashSet<Vector2Int> floorPositions)
        {
            SetTiles(floorPositions, floorTilemap, floorTile);
        }

        public void SetChestTiles(HashSet<Vector2Int> chestPositions)
        {
            SetTiles(chestPositions, objectTilemap, chestTile);
        }

        public void SetLadderTiles(HashSet<Vector2Int> ladderPositions)
        {
            SetTiles(ladderPositions, objectTilemap, ladderTile);
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
}