using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public enum Direction
    {
        Left,
        Up,
        Right,
        Down
    }

    public class Enemy : Creature
    {
        public Player Player;
        private RaycastHit2D hit;
        private BoxCollider2D boxCollider;
        public double timer = 0;

        public Enemy() : base() {} 
        
        public Enemy(Vector2 coordinates)
        {
            Enemy enemy = gameObject.AddComponent<Enemy>();
            enemy.transform.position = (Vector3)coordinates;
        }
        private void Start()
        {
            this.Health = GetComponent<Health>();
            boxCollider = GetComponent<BoxCollider2D>();
        }
        void Update()
        {
            Move();
        }
    
        public override void Move()
        {
            
            timer += Time.deltaTime;
            if (timer < MoveCooldown) return;
            
            Vector3 direction = Player.transform.position - transform.position;
            
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