using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Update = UnityEngine.PlayerLoop.Update;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : Creature
{
    private BoxCollider2D boxCollider;
    private Vector2 moveDelta;
    private RaycastHit2D hit;
    public float movementSpeed = 1f;
    public float timer = 0;
    public float cooldown = 0.05f;

    public Animator animator;

    //[SerializeField] private UI_Inventory uiInventory;
    //private Inventory inventory;

    private RoomDungeonGenerator room;
    public Vector3 ladderPos;

    
    private void Start()
    {
        //inventory = new Inventory();
        boxCollider = GetComponent<BoxCollider2D>();
        room = GameObject.Find("RoomDungeonGenerator").GetComponent<RoomDungeonGenerator>();
        //Debug.Log("Start");
        //uiInventory.SetInventory(inventory);

    }
    //private void Awake()
    //{
    //    //inventory = new Inventory();
    //    uiInventory.SetInventory(inventory);
    //    Debug.Log("Player Awake");
    //}
    private void Update()
    {
        moveDelta.x = Input.GetAxisRaw("Horizontal");
        moveDelta.y = Input.GetAxisRaw("Vertical");
        
        if (transform.position == ladderPos)
        {
            room.GenerateDungeon();
        }
    }

    public override void Attack()
    {
                
    }
    public override void Move()
    {
        timer += Time.deltaTime;
        if (timer < cooldown) return;

        switch (moveDelta.x)
        {
            // Player rotation
            case > 0:
                transform.localScale = new Vector3(6.25f, 6.25f, 0f);
                break;
            case < 0:
                transform.localScale = new Vector3(-6.25f, 6.25f, 0f);
                break;
        }

        // X axis collidetation
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, moveDelta.y),
            Mathf.Abs(moveDelta.x * movementSpeed) + Mathf.Abs(moveDelta.y * movementSpeed), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider) return;
        if (moveDelta != Vector2.zero)
        {
            transform.Translate(moveDelta.x * movementSpeed, moveDelta.y * movementSpeed, 0);
            timer = 0;
            animator.SetTrigger("IsMoving");
        }
    }

    public void TeleportToTileCoordinates(Vector2Int coordinates)
    {
        var position = (Vector2) coordinates;
        position.x += 0.5f;
        transform.position = (Vector3) position;
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    public void SetLadderPos(Vector2Int floor)
    {
        var position = (Vector2) floor;
        position.x += 0.5f;
        ladderPos = position;
    }
}