using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.CardinalDirectionsList);
        var cornerWallPositions = FindWallsInDirections(floorPositions, Direction2D.DiagonalDirectionsList);
        CreatePlainWall(tilemapVisualizer, basicWallPositions, floorPositions);
        CreateCornerWalls(tilemapVisualizer, cornerWallPositions, floorPositions);
    }

    private static void CreateCornerWalls(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerWallPositions,
        HashSet<Vector2Int> floorPositions)
    {
        //frankly, the builder in this case saves astronomically little time, but let it be
        var builder = new StringBuilder(8);
        foreach (var position in cornerWallPositions)
        {
            foreach (var neighbourPosition in Direction2D.EightDirectionsList.Select(direction => position + direction))
                builder.Append(floorPositions.Contains(neighbourPosition) ? "1" : "0");

            var neighboursBinaryType = builder.ToString();
            builder.Clear();
            tilemapVisualizer.SetSingleCornerWall(position, neighboursBinaryType);
        }
    }

    private static void CreatePlainWall(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> basicWallPositions,
        HashSet<Vector2Int> floorPositions)
    {
        var builder = new StringBuilder(4);
        foreach (var position in basicWallPositions)
        {
            foreach (var neighbourPosition in Direction2D.CardinalDirectionsList.Select(direction =>
                         position + direction)) builder.Append(floorPositions.Contains(neighbourPosition) ? "1" : "0");

            var neighboursBinaryType = builder.ToString();
            builder.Clear();
            tilemapVisualizer.SetSingleBasicWall(position, neighboursBinaryType);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions,
        IReadOnlyCollection<Vector2Int> directionList)
    {
        var wallPositions = new HashSet<Vector2Int>();
        foreach (var neighbourPosition in floorPositions
                     .SelectMany(position => directionList, (position, direction) => position + direction)
                     .Where(neighbourPosition => floorPositions.Contains(neighbourPosition) == false))
            wallPositions.Add(neighbourPosition);

        return wallPositions;
    }
}