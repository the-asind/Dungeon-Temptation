using DungeonCreature;
using UnityEngine;

namespace _Scripts.DungeonGenerator
{
    public abstract class AbstractDungeonGenerator : MonoBehaviour
    {
        [SerializeField] protected TilemapVisualizer tilemapVisualizer;
        [SerializeField] protected PlayerBehaviour player;
        [SerializeField] protected EnemySpawner e;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

        private void Awake()
        {
            
            FindObjectOfType<AudioManager>();
            player = GetComponent<PlayerBehaviour>();
            e = GetComponent<EnemySpawner>();
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