using UnityEngine;

namespace DungeonCreature
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Sprite renderer;
        [SerializeField] private EnemyList _enemyList;

        public void SpawnEnemy(Vector2 coordinates)
        {
            _enemyList.CreateEnemy(coordinates, renderer);
        }

        public void ClearEnemyList()
        {
            _enemyList.Clear();
        }
    }
}