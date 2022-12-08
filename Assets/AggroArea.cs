using System;
using System.Collections;
using System.Collections.Generic;
using DungeonCreature;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AggroArea : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        PlayerTransform Player = GetComponentInParent<PlayerTransform>();
        Player.PlayerPosition = (collider.gameObject.CompareTag("Player")) ? collider.GetComponent<Transform>() : null;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        
        PlayerTransform Player = GetComponentInParent<PlayerTransform>();
        if (collider.gameObject.CompareTag("Player"))
        {
            Player.PlayerPosition = null;
        }
    }
}