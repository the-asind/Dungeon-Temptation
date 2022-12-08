using UnityEngine;

namespace _Scripts.DungeonGenerator
{
    [CreateAssetMenu(fileName = "SimpleRandomWalkParameters_", menuName = "PCG/SimpleRandomWalkData")]
    public class SimpleRandomWalkSO : ScriptableObject
    {
        public int iterations = 10, walkLength = 10;
        public bool startRandomlyEachIteration = true;
    }
}