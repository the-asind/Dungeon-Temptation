using System.Collections.Generic;
using System.Linq;
using DungeonCreature;
using UnityEngine;
using Random = System.Random;

namespace _Scripts.DungeonGenerator
{
    public static class ObjectGenerator
    {
        public static void GenerateCreatures(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer,
            Player player, EnemySpawner e)
        {
            var chestPositions = new HashSet<Vector2Int>();
            var enemyPositions = new HashSet<Vector2Int>();
            var ladderPosition = new HashSet<Vector2Int>();
            var take = floorPositions.Count / 20;
            take = take % 2 == 0 ? take : take + 1;

            var r = new Random();
            foreach (var floor in floorPositions
                         .OrderBy(_ => r.Next())
                         .Take(take))
            {
                while (chestPositions.Count < take / 2 - 1)
                {
                    chestPositions.Add(floor);
                    break;
                }

                while (enemyPositions.Count < take / 2 - 1)
                {
                    enemyPositions.Add(floor);
                    break;
                }

                if (ladderPosition.Count == 0) // more ladders in future could be.
                {
                    ladderPosition.Add(floor);
                    player.SetLadderPos(floor);
                    continue;
                }

                player.TeleportToTileCoordinates(floor);
            }

            tilemapVisualizer.SetChestTiles(chestPositions);
            tilemapVisualizer.SetLadderTiles(ladderPosition);

            foreach (var enemyPosition in enemyPositions)
            {
                //не работает код ниже:
                //e.SpawnEnemy(CoordinateManipulation.ToWorldCoord(enemyPosition));
            }
        }
    }
}