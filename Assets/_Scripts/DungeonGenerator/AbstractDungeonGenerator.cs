using DefaultNamespace;
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
            tilemapVisualizer.Clear();
            e = gameObject.AddComponent<EnemySpawner>();
        }

        public void GenerateDungeon()
        {
            FindObjectOfType<AudioManager>().PlayNextMusic();
            RunProceduralGeneration();
        }

        protected abstract void RunProceduralGeneration();
    }
}