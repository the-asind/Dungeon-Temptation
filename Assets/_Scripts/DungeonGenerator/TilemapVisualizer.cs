using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace _Scripts.DungeonGenerator
{
    public class TilemapVisualizer : MonoBehaviour
    {
        [SerializeField] private Tilemap floorTilemap, wallTilemap, objectTilemap;

        [SerializeField] private TileBase
            // Floors
            floorTile,
            floor1,
            floor2,
            floor3,
            floor4, 
            // Walls
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
            chestTile;

        [SerializeField] private TileBase
            ladderTile,
            hatchTile,
            // Decorative Floor Tiles
            dftSkull,
            dftRocks,
            // Decorative Wall Tiles
            dwtBanner,
            dwtTorch;


        public void SetFloorTiles(HashSet<Vector2Int> floorPositions)
        {
            foreach (var position in floorPositions)
            {
                switch (Random.Range(1, 5))
                {
                    case 1:
                        SetSingleTile(floorTilemap, floor1, position);
                        break;
                    case 2:
                        SetSingleTile(floorTilemap, floor2, position);
                        break;
                    case 3:
                        SetSingleTile(floorTilemap, floor3, position);
                        break;
                    case 4:
                        SetSingleTile(floorTilemap, floor4, position);
                        break;
                }
            }
                
        }

        public void SetChestTiles(HashSet<Vector2Int> chestPositions)
        {
            SetTiles(chestPositions, objectTilemap, chestTile);
        }

        public void SetLadderTiles(HashSet<Vector2Int> ladderPositions)
        {
            SetTiles(ladderPositions, objectTilemap, ladderTile);
        }

        public void SetHatchTiles(Vector2Int hatchPosition)
        {
            SetSingleTile(objectTilemap, hatchTile, hatchPosition);
        }
        
        public void SetDecorativeFloorTiles(HashSet<Vector2Int> decorativeFloorTilesPositions)
        {
            foreach (var position in decorativeFloorTilesPositions)
            {
                if (Random.value > 0.5)
                    SetSingleTile(objectTilemap, dftRocks, position);
                else SetSingleTile(objectTilemap, dftSkull, position);
            }
        }
        
        public void SetDecorativeWallTile(Vector2Int decorativeFloorTilesPosition)
        {
            if (Random.value > 0.5)
                SetSingleTile(objectTilemap, dwtBanner, decorativeFloorTilesPosition);
            else SetSingleTile(objectTilemap, dwtTorch, decorativeFloorTilesPosition);
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
            else if (WallHashType.WallFull.Contains(typeAsByte)) 
                tile = wallFull;

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
            else if (WallHashType.WallBottomEightDirections.Contains(typeAsByte)) 
                tile = wallBottom;
            else if (WallHashType.WallOnlyTop.Contains(typeAsByte))
            {
                tile = wallTop;
                SetSingleTile(wallTilemap, tile, position);
                if (Random.value > 0.8)
                    SetDecorativeWallTile(position);
                return;
            }
            
            if (tile)
                SetSingleTile(wallTilemap, tile, position);
        }
    }
}