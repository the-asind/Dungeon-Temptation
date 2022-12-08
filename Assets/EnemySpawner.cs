using UnityEngine;

namespace DungeonCreature
{
    public class EnemySpawner : MonoBehaviour
    {
        private System.Random r;
        public Sprite[] Sprites;
        public RuntimeAnimatorController[] Animations;
        public void SpawnEnemy(Vector2 coordinates)
        {
            Enemy enemy = gameObject.AddComponent<Enemy>();
            int index = r.Next(0, Sprites.Length);
            enemy.transform.position = coordinates;
            enemy.sr.sprite = Sprites[index];
            enemy.Animator.runtimeAnimatorController = Animations[index];
            enemy.boxCollider.size = new Vector2(0.1f,0.1f);
        }

        public EnemySpawner()
        {
            r = new System.Random();
        }
    }
}