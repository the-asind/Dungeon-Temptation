using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector2 moveDelta;
    private Vector2 target;
    private RaycastHit2D hit;
    public float movementSpeed = 0.16f;
    public float nextWalkTime = 0;
    public float Cooldown = 0.05f;
    Vector2 currentVelocity;
    public float smoothTime = 0.1f;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        moveDelta.x = Input.GetAxisRaw("Horizontal");
        moveDelta.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (Time.time < nextWalkTime) return;
        // Player rotation
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // X axis collidetation
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, moveDelta.y),
            Mathf.Abs(moveDelta.x * movementSpeed) + Mathf.Abs(moveDelta.y * movementSpeed), LayerMask.GetMask("Actor", "Blocking"));
        
        // Smooth tile walking. Currently doesn't work
        target.x = moveDelta.x * movementSpeed;
        //target.x -= target.x % movementSpeed
        target.y = moveDelta.y * movementSpeed;
        //target.y -= target.y % movementSpeed;
        
        if (hit.collider == null && Time.time > nextWalkTime)
        {
            //transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
            transform.Translate(moveDelta.x * movementSpeed, moveDelta.y * movementSpeed, 0);
            nextWalkTime = Time.time + Cooldown;
        }
    }
}