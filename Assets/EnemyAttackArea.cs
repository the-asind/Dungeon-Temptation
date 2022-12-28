using UnityEngine;

namespace DungeonCreature
{
    public class EnemyAttackArea : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.GetComponent<PlayerBehaviour>() != null)
            {
                EnemyBehaviour enemyBehaviour = transform.parent.gameObject.GetComponent<EnemyBehaviour>();
                PlayerBehaviour playerBehaviour = collider.gameObject.GetComponent<PlayerBehaviour>();
                enemyBehaviour._behaviourModel.Attack(playerBehaviour._behaviourModel.Player);
            }
        }
    }
}