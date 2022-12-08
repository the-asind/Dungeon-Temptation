using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        } 
    }
    
}
