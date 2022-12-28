using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject attackArea;

    private bool attacking = false;

    private float _attackCooldown => gameObject.GetComponent<EnemyBehaviour>()._behaviourModel.ProvideAttackCooldown();
    private float timeToAttack = 0.25f;

    private float timeToAttackTimer = 0f;
    private float AttackCooldownTimer = 0f;
    
    void Start()
    {
        attackArea = gameObject.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (!(AttackCooldownTimer > _attackCooldown))
        {
            AttackCooldownTimer += Time.deltaTime;
            return;
        }

        Attack();
        
        if (attacking)
        {
            timeToAttackTimer += Time.deltaTime;

            if (timeToAttackTimer >= timeToAttack)
            {
                timeToAttackTimer = 0;
                AttackCooldownTimer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
