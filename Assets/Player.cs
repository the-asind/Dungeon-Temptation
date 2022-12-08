using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : Creature
{
    private BoxCollider2D boxCollider;
    private Vector2 moveDelta;
    private RaycastHit2D hit;
    public float timer = 0;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        moveDelta.x = Input.GetAxisRaw("Horizontal");
        moveDelta.y = Input.GetAxisRaw("Vertical");
    }

    public void Teleport(Vector2Int coordinates)
    {
        transform.position = (Vector3Int)coordinates;
    }

    public override void Move()
    {
        timer += Time.deltaTime;
        if (timer < MoveCooldown) return;

        GameObject attackArea = transform.GetChild(0).gameObject;

        // Player rotation, AttackArea rotation doesn't work
        if (moveDelta.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            attackArea.transform.rotation = new Quaternion(0f, 0f, 0.70711f, -0.70711f);
            //transform.localScale = new Vector3(6.25f, 6.25f, 6.25f);
        }
        else if (moveDelta.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            
            attackArea.transform.rotation = new Quaternion(0f, 0f, 0.70711f, 0.70711f);
            //transform.localScale = new Vector3(-6.25f, 6.25f, 6.25f);
        }
        else if (moveDelta.y > 0)
        {
            attackArea.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
        }
        else if (moveDelta.y < 0)
        {
            attackArea.transform.rotation = new Quaternion(0f, 0f, 1, 0f);
        }
        Debug.Log(attackArea.transform.rotation);
        // X axis collidetation
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, moveDelta.y),
            Mathf.Abs(moveDelta.x) + Mathf.Abs(moveDelta.y), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider) return;
        if (moveDelta != Vector2.zero)
        {
            transform.Translate(moveDelta.x, moveDelta.y, 0);
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}