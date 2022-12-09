using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private uint _damage = 3;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collider.transform.parent.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
        } 
    }
    
}
