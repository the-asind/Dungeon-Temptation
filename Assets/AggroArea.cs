using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DungeonCreature;
using DungeonCreature.BehaviourModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector3 = UnityEngine.Vector3;

public class AggroArea : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        EnemyBehaviour behaviour = GetComponentInParent<EnemyBehaviour>();
        if (!collider.gameObject.CompareTag("Player"))
        {
            behaviour._behaviourModel.Enemy.Target = null;
            return;
        }

        PlayerBehaviour player = collider.gameObject.GetComponent<PlayerBehaviour>();
        behaviour._behaviourModel.Enemy.Target = player._behaviourModel.Player;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        EnemyBehaviour behaviour = GetComponentInParent<EnemyBehaviour>();
        if (collider.gameObject.CompareTag("Player"))
            behaviour._behaviourModel.Enemy.Target = null;
    }
}