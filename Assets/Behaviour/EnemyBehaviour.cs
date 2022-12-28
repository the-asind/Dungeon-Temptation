using DungeonCreature.BehaviourModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace DungeonCreature
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public EnemyBehaviourModel _behaviourModel;
        private RaycastHit2D _collision;
        private BoxCollider2D _collider;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private Rigidbody2D _rb;
        private GameObject _aggroArea;
        public double timer;

        public void Awake()
        {
            _behaviourModel = new EnemyBehaviourModel(transform.position.x, transform.position.y);
            AddComponents(); 
            AddAttackArea();
            _behaviourModel.PositionChanged += OnPositionChanged;
            _behaviourModel.HealthChanged += OnHealthChanged;
            _behaviourModel.Die += OnDie;
        }

        private void AddComponents()
        {
            this.gameObject.layer = LayerMask.NameToLayer("Actor");
            _collider = gameObject.AddComponent<BoxCollider2D>();
            _collider.size = new Vector2(0.5f, 0.5f);
            _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            _animator = gameObject.AddComponent<Animator>();
            _rb = gameObject.AddComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;
        }
        
        private void AddAttackArea()
        {
            _aggroArea = new GameObject();
            _aggroArea.transform.parent = transform;
            _aggroArea.gameObject.AddComponent<AggroArea>();
            
            CircleCollider2D aggroAreaCollider = _aggroArea.AddComponent<CircleCollider2D>();
            aggroAreaCollider.isTrigger = true;
            aggroAreaCollider.radius = 5;
        }
        
        private void OnDie()
        {
            Destroy(gameObject);
        }
        private void OnHealthChanged()
        {
            
        }
        private void OnPositionChanged()
        {
            Position position = _behaviourModel.ProvidePosition();
            transform.position = new Vector3(position.X, position.Y, 0);
        } 
        void Update()
        {
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
            if (timer < _behaviourModel.ProvideCooldown() || _behaviourModel.CheckTarget()) return;
                        
            Vector3 targetPosition =
                new Vector3(_behaviourModel.Enemy.Target.Position.X, _behaviourModel.Enemy.Target.Position.Y, 0);
            
            Vector3 direction = targetPosition - transform.position;
            direction.Normalize();
            direction.x = Mathf.Round(direction.x);
            direction.y = Mathf.Round(direction.y);

            // Sprite rotation
            Rotate(direction);
            CheckCollision(direction);

            if (_collision.collider) return;
            if (direction != Vector3.zero)
            {
                _behaviourModel.ChangePosition(direction.x + _behaviourModel.ProvidePosition().X, direction.y + _behaviourModel.ProvidePosition().Y);   
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