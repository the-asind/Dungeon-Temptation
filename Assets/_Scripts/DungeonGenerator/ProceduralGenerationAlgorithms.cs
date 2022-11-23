using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithms
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
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
        var corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPosition = startPosition;
        corridor.Add(currentPosition);

        for (var i = 0; i < corridorLength; i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }

        return corridor;
    }

    public static List<BoundsInt> BinarySpacePartitioning(BoundsInt spaceToSplit, int minWidth, int minHeight)
    {
        var roomsQueue = new Queue<BoundsInt>();
        var roomsList = new List<BoundsInt>();
        roomsQueue.Enqueue(spaceToSplit);
        while (roomsQueue.Count > 0)
        {
            var room = roomsQueue.Dequeue();
            if (room.size.y < minHeight || room.size.x < minWidth) continue;
            switch (Random.value)
            {
                case < 0.5f when room.size.y >= minHeight * 2:
                    SplitHorizontally(roomsQueue, room);
                    break;
                case < 0.5f when room.size.x >= minWidth * 2:
                    SplitVertically(roomsQueue, room);
                    break;
                case < 0.5f:
                    if (room.size.x >= minWidth && room.size.y >= minHeight) roomsList.Add(room);

                    break;
                default:
                    if (room.size.x >= minWidth * 2)
                        SplitVertically(roomsQueue, room);
                    else if (room.size.y >= minHeight * 2)
                        SplitHorizontally(roomsQueue, room);
                    else if (room.size.x >= minWidth && room.size.y >= minHeight) roomsList.Add(room);

                    break;
            }
        }

        return roomsList;
    }

    private static void SplitVertically(Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var xSplit = Random.Range(1, room.size.x);
        var room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.size.y, room.size.z));
        var room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z),
            new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));
        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }

    private static void SplitHorizontally(Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var ySplit = Random.Range(1, room.size.y);
        var room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));
        var room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.min.z),
            new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));
        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }
}

public static class Direction2D
{
    public static readonly List<Vector2Int> CardinalDirectionsList;

    public static readonly List<Vector2Int> DiagonalDirectionsList;

    public static readonly List<Vector2Int> EightDirectionsList;

    static Direction2D()
    {
        EightDirectionsList = new List<Vector2Int>
        {
            new(0, 1), //Top
            new(1, 1), //Top-Right
            new(1, 0), //Right
            new(1, -1), //Right-Bottom
            new(0, -1), // Bottom
            new(-1, -1), // Bottom-Left
            new(-1, 0), //Left
            new(-1, 1) //Left-Top
        };
        CardinalDirectionsList = new List<Vector2Int>
        {
            new(0, 1), //Top
            new(1, 0), //Right
            new(0, -1), // Bottom
            new(-1, 0) //Left
        };
        DiagonalDirectionsList = new List<Vector2Int>
        {
            new(1, 1), //Top-Right
            new(1, -1), //Right-Bottom
            new(-1, -1), // Bottom-Left
            new(-1, 1) //Left-Top
        };
    }

    public static Vector2Int GetRandomCardinalDirection()
    {
        return CardinalDirectionsList[Random.Range(0, CardinalDirectionsList.Count)];
    }
}