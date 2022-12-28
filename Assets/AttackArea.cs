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
                gameObject.GetComponent<PlayerBehaviour>();
            EnemyBehaviour behaviour = collider.GetComponent<EnemyBehaviour>();
             
        }

        if (collider.GetComponent<PlayerBehaviour>() != null)
        {
            
        }
    }
}
