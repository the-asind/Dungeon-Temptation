using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour
    {
        public Transform player;
        private Vector2 movement;
        private RaycastHit2D hit;
        private BoxCollider2D boxCollider;
        public float movementSpeed = 0.16f;
        public float Cooldown = 0.3f;
        public float nextWalkTime = 0;

        private void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            if (Time.time < nextWalkTime) return;
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            
            // Sprite rotation
            if (transform.position.x < player.position.x)
                transform.localScale = Vector3.one;
            else if (transform.position.x > player.position.x)
                transform.localScale = new Vector3(-1, 1, 1);

            // X axis collidetation
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(direction.x, direction.y),
                Mathf.Abs(direction.x * movementSpeed) + Mathf.Abs(direction.y * movementSpeed),
                LayerMask.GetMask("Actor", "Blocking"));
            
            if (hit.collider == null && Time.time > nextWalkTime)
            {
                //transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
                transform.Translate(direction.x * movementSpeed, direction.y * movementSpeed, 0);
                nextWalkTime = Time.time + Cooldown;
            }
            nextWalkTime += Cooldown;
        }
    }
}