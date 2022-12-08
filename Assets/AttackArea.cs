using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        } 
    }
    
}
