using UnityEngine;
using UnityEngine.Serialization;

namespace DungeonCreature
{
    public class EnemySpawner : MonoBehaviour
    {
        private System.Random r;
        public Sprite sprite;
        private EnemyList _enemyList = new EnemyList();
        
        //public RuntimeAnimatorController[] Animations;
        
        // void Start() {
        //     SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        //     renderer.sprite = Sprite;
        // }
        
        public void SpawnEnemy(Vector2 coordinates)
        {
            
            //int index = r.Next(0, Sprite.Length);
            _enemyList.CreateEnemy(coordinates, sprite);
            
        }

        public EnemySpawner()
        {
            r = new System.Random();
            //Animations = new RuntimeAnimatorController[1];
        }
    }
}