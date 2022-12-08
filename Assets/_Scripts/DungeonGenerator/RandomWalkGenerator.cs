using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts.DungeonGenerator
{
    public class RandomWalkGenerator : AbstractDungeonGenerator
    {
        [SerializeField] protected SimpleRandomWalkSO randomWalkParameters;


        protected override void RunProceduralGeneration()
        {
            var floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
            tilemapVisualizer.Clear();
            tilemapVisualizer.SetFloorTiles(floorPositions);
            WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
        }

        protected static HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position)
        {
            var currentPosition = position;
            var floorPositions = new HashSet<Vector2Int>();
            for (var i = 0; i < parameters.iterations; i++)
            {
                var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength);
                floorPositions.UnionWith(path);
                if (parameters.startRandomlyEachIteration)
                    currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }

            return floorPositions;
        }
    }
}