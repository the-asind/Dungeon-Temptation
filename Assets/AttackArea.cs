using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyBehaviour>() != null)
        {
            PlayerBehaviour playerBehaviour = 
                transform.parent.gameObject.GetComponent<PlayerBehaviour>();
            EnemyBehaviour enemyBehaviour = collider.gameObject.GetComponent<EnemyBehaviour>();
            playerBehaviour._behaviourModel.Attack(enemyBehaviour._behaviourModel.Enemy);
        }

        if (collider.GetComponent<PlayerBehaviour>() != null)
        {
            EnemyBehaviour enemyBehaviour = transform.parent.gameObject.GetComponent<EnemyBehaviour>();
            PlayerBehaviour playerBehaviour = collider.gameObject.GetComponent<PlayerBehaviour>();
            enemyBehaviour._behaviourModel.Attack(playerBehaviour._behaviourModel.Player);
        }
    }
}
