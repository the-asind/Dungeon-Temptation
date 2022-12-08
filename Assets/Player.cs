using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
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
    private SpriteRenderer sr;
    private Animator animator;

    private RoomDungeonGenerator room;
    public Vector3 ladderPos;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        Health = GetComponent<Health>();
        sr = GetComponent<SpriteRenderer>();
        room = GameObject.Find("RoomDungeonGenerator").GetComponent<RoomDungeonGenerator>();
    }
    private void Update()
    {
        moveDelta.x = Input.GetAxisRaw("Horizontal");
        moveDelta.y = Input.GetAxisRaw("Vertical");
        
        if (transform.position == ladderPos)
        {
            room.GenerateDungeon();
        }
    }

    public override void Move()
    {
        timer += Time.deltaTime;
        if (timer < MoveCooldown) return;

        GameObject attackArea = transform.GetChild(0).gameObject;

        if (moveDelta.x > 0)
        {
            sr.flipX = false;
            attackArea.transform.rotation = new Quaternion(0f, 0f, 0.70711f, -0.70711f);
        }
        else if (moveDelta.x < 0)
        {
            sr.flipX = true;
            attackArea.transform.rotation = new Quaternion(0f, 0f, 0.70711f, 0.70711f);
        }
        else if (moveDelta.y > 0)
        {
            attackArea.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
        }
        else if (moveDelta.y < 0)
        {
            attackArea.transform.rotation = new Quaternion(0f, 0f, 1, 0f);
        }
        
        // X axis collidetation
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, moveDelta.y),
            Mathf.Abs(moveDelta.x * movementSpeed) + Mathf.Abs(moveDelta.y * movementSpeed), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider) return;
        if (moveDelta != Vector2.zero)
        {
            transform.Translate(moveDelta.x, moveDelta.y, 0);
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