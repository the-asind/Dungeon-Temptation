using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DungeonCreature;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector3 = UnityEngine.Vector3;

public class AggroArea : MonoBehaviour
{
    public Vector3 PlayerPosition { get; set; }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Player"))
        {
            PlayerPosition = Vector3.zero;
            return;
        }
        
        Vector3 player = collider.transform.position;
        PlayerPosition = player;
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            PlayerPosition = Vector3.zero;
    }
}