using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerationAlgorithms : MonoBehaviour
{
    public static IEnumerable<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        var path = new HashSet<Vector2Int> { startPosition };

        var previousPosition = startPosition;

        for (var i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }

        return path;
    }
}

public static class Direction2D
{
    private static readonly List<Vector2Int> CardinalDirectionList = new()
    {
        new Vector2Int(0, 1), //UP
        new Vector2Int(1, 0), //RIGHT
        new Vector2Int(0, -1), //DOWN
        new Vector2Int(-1, 0) //LEFT
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return CardinalDirectionList[Random.Range(0, 4)];
    }
}