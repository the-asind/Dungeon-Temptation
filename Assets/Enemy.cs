using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour
    {
        public Transform player;
        private Rigidbody2D rb;
        private Vector2 movement;
        public float movementSpeed = 0.16f;
        public float Cooldown = 0.3f;
        public float nextWalkTime = 0;

        void Start()
        {
            rb = this.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Time.time < nextWalkTime) return;
            Vector3 direction = player.position - transform.position;

            if (transform.position.x < player.position.x)
                transform.localScale = Vector3.one;
            else if (transform.position.x > player.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            
            direction.Normalize();
            movement = direction;
            MoveCharacter(movement);
            nextWalkTime += Cooldown;
        }

        void MoveCharacter(Vector2 direction)
        {
            rb.MovePosition((Vector2)transform.position + (direction * movementSpeed));
        }
    }
}