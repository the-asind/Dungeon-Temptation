using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<EnemyBehaviour>() != null)
        {
            PlayerBehaviour playerBehaviour = 
                transform.parent.gameObject.GetComponent<PlayerBehaviour>();
            EnemyBehaviour enemyBehaviour = collider.gameObject.GetComponent<EnemyBehaviour>();
            playerBehaviour._behaviourModel.Attack(enemyBehaviour._behaviourModel.Enemy);
        }
    }
}
