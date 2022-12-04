using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace _Scripts.DungeonGenerator
{
    public static class ObjectGenerator
    {
        public static void GenerateCreatures(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
        {
            var objectPositions = new HashSet<Vector2Int>();
            var take = floorPositions.Count/20;
            
            var r = new Random();
            foreach(var floor in floorPositions
                        .OrderBy(x => r.Next())
                        .Take(take))
            {
                objectPositions.Add(floor);
            }

            tilemapVisualizer.SetObjectTiles(objectPositions);
        }
    }
}