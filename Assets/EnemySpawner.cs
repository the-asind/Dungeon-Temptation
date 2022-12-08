using UnityEngine;

namespace DungeonCreature
{
    public class EnemySpawner : MonoBehaviour
    {
        public EnemySpawner() {}
        public void SpawnEnemy(Vector2 coordinates)
        {
            Enemy enemy = gameObject.AddComponent<Enemy>();
            enemy.transform.position = coordinates;
        }
    }
}