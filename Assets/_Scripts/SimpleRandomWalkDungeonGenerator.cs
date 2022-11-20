using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField] protected new Vector2Int startPosition = Vector2Int.zero;
    [SerializeField] private int iterations = 10;
    [SerializeField] public int walkLength = 10;
    [SerializeField] public bool startRandomlyEachIteration = true;
    protected override void RunProceduralGeneration()
    {
        var floorPositions = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
    }

    private IEnumerable<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        var floorPositions = new HashSet<Vector2Int>();
        for (var i = 0; i < iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);
            if (startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }

        return floorPositions;
    }
}