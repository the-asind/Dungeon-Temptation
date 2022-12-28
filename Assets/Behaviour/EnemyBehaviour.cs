using UnityEngine;
using UnityEngine.Serialization;

namespace DungeonCreature
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private Enemy _enemy = new Enemy();
        public Transform player;
        private RaycastHit2D _collision;
        private BoxCollider2D _collider;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private GameObject _attackArea;
        public double timer = 0;

        public void Awake()
        {
            this._collider = gameObject.AddComponent<BoxCollider2D>();
            this._spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            this._animator = gameObject.AddComponent<Animator>();
        }

        void Update()
        {
            if (player != null)
                Move();
        }
        public void ChangeSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
        public void ChangeAnimation(RuntimeAnimatorController controller)
        {
            _animator.runtimeAnimatorController = controller;
        }
        public void ChangeCollider(BoxCollider2D collider)
        {
            _collider = collider;
        }
        public void Move()
        {
            timer += Time.deltaTime;
            if (timer < _enemy.MoveCooldown) return;

            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            direction.x = Mathf.Round(direction.x);
            direction.y = Mathf.Round(direction.y);

            // Sprite rotation
            Rotate(direction);
            CheckCollision(direction);

            if (_collision.collider) return;
            if (direction != Vector3.zero)
            {
                transform.Translate(direction.x, direction.y, 0);
                timer = 0;
            }
        }

        private void CheckCollision(Vector3 direction)
        {
            _collision = Physics2D.BoxCast(transform.position, _collider.size, 0, new Vector2(direction.x, direction.y),
                Mathf.Abs(direction.x) + Mathf.Abs(direction.y),
                LayerMask.GetMask("Actor", "Blocking"));
        }

        private void Rotate(Vector3 direction)
        {
            _spriteRenderer.flipX = (direction.x > 0) ? false : true;
        }
    }
}