using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace _Scripts
{
    public static class CoordinateManipulation
    {
        public static Vector3 ToWorldCoord(Vector2Int tileCoord)
        {
            var position = (Vector2) tileCoord;
            position.x += 0.5f;
            position.y += 0.5f;
            return (Vector3)position;
        }
    
        public static Vector2Int ToTileCoord(Vector3 worldCoord)
        {
            return new Vector2Int((int) worldCoord.x, (int) worldCoord.y) ;
        }
    }
}