using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : Creature
{
    private BoxCollider2D boxCollider;
    private Vector2 moveDelta;
    private RaycastHit2D hit;
    public float movementSpeed = 1f;
    public float timer = 0;
    public float Cooldown = 0.05f;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        moveDelta.x = Input.GetAxisRaw("Horizontal");
        moveDelta.y = Input.GetAxisRaw("Vertical");
    }

    public override void Attack()
    {
                
    }
    public override void Move()
    {
        timer += Time.deltaTime;
        if (timer < Cooldown) return;

        switch (moveDelta.x)
        {
            // Player rotation
            case > 0:
                transform.localScale = new Vector3(6.25f, 6.25f, 6.25f);
                break;
            case < 0:
                transform.localScale = new Vector3(-6.25f, 6.25f, 6.25f);
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
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
}