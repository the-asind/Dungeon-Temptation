using DungeonCreature;
using UnityEngine;

namespace _Scripts.DungeonGenerator
{
    public abstract class AbstractDungeonGenerator : MonoBehaviour
    {
        [SerializeField] protected TilemapVisualizer tilemapVisualizer;
        [SerializeField] protected Player player;
        [SerializeField] protected EnemySpawner e;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

        private void Awake()
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            e = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();
        }

        public void GenerateDungeon()
        {
            FindObjectOfType<AudioManager>().PlayNextMusic();
            tilemapVisualizer.Clear();
            RunProceduralGeneration();
        }

        protected abstract void RunProceduralGeneration();
    }
}