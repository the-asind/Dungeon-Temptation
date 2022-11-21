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

    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List <Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPosition = startPosition;-.
        corridor.Add(currentPosition);
        
        for (int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }

        return corridor;
    }
}

public static class Direction2D
{
    public static readonly List<Vector2Int> CardinalDirectionList = new()
    {
        new Vector2Int(0, 1), //UP
        new Vector2Int(1, 0), //RIGHT
        new Vector2Int(0, -1), //DOWN
        new Vector2Int(-1, 0) //LEFT
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return CardinalDirectionList[Random.Range(0, 4)]; // 0-4 -- up,right,left,down
    }
}