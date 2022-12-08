﻿using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DungeonCreature
{
    public class Enemy : Creature
    {
        private PlayerTransform Player;
        private RaycastHit2D hit;
        public BoxCollider2D boxCollider;
        public double timer = 0;
        public SpriteRenderer sr;
        public Animator Animator; 
        public Enemy() : base()
        {
        }

        public Enemy(Vector2 coordinates)
        {
            Enemy enemy = gameObject.AddComponent<Enemy>();
            enemy.transform.position = (Vector3)coordinates;
        }

        private void Start()
        {
            this.Health = GetComponent<Health>();
            Player = gameObject.AddComponent<PlayerTransform>();
            boxCollider = GetComponent<BoxCollider2D>();
            sr = gameObject.AddComponent<SpriteRenderer>();
            Animator = gameObject.AddComponent<Animator>();
        }

        void Update()
        {
            if (Player.PlayerPosition != null)
                Move();
        }

        public override void Move()
        {
            timer += Time.deltaTime;
            if (timer < MoveCooldown) return;

            Vector3 direction = Player.PlayerPosition.position - transform.position;
            direction.Normalize();
            
            direction.x = Mathf.Round(direction.x);
            direction.y = Mathf.Round(direction.y);
            
            Debug.Log(direction); 
            // Sprite rotation
            if (direction.x > 0)
                transform.localScale = new Vector3(6.25f, 6.25f, 6.25f);
            else if (direction.x < 0)
                transform.localScale = new Vector3(-6.25f, 6.25f, 6.25f);

            // X axis collidetation
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(direction.x, direction.y),
                Mathf.Abs(direction.x) + Mathf.Abs(direction.y),
                LayerMask.GetMask("Actor", "Blocking"));

            if (hit.collider) return;
            if (direction != Vector3.zero)
            {
                transform.Translate(direction.x, direction.y, 0);
                timer = 0;
            }
        }
    }
}