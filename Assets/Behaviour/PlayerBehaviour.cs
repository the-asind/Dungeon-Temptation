using _Scripts;
using _Scripts.DungeonGenerator;
using DungeonCreature.BehaviourModel;
using Unity.VisualScripting;
using UnityEngine;

namespace DungeonCreature
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private PlayerBehaviourModel _behaviourModel = new PlayerBehaviourModel();
        private BoxCollider2D _collider;
        private Vector2 _moveDirection;
        private RaycastHit2D _collision;
        public float timer;
        private SpriteRenderer _sr;
        private Animator _animator;
        private RoomDungeonGenerator _room;
        private AttackArea _attackArea;
        public Vector3 ladderPos;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<BoxCollider2D>();
            _sr = GetComponent<SpriteRenderer>();
            _attackArea = GetComponent<AttackArea>();
            _room = GameObject.Find("RoomDungeonGenerator").GetComponent<RoomDungeonGenerator>();
            _behaviourModel.Die += OnDie;
        }

        private void OnDie()
        {
            PlayerBehaviour behaviour = gameObject.GetComponent<PlayerBehaviour>();
            Destroy(behaviour);
        }
        private void OnPositionChanged()
        {
            Position position = _behaviourModel.ProvidePosition();
            transform.Translate(position.x, position.y, 0);
        }

        private float _progress;
        private void Update()
        {
            _moveDirection.x = Input.GetAxisRaw("Horizontal");
            _moveDirection.y = Input.GetAxisRaw("Vertical");

            if (transform.position == ladderPos) _room.GenerateDungeon();
            //TODO:
            _progress =  _behaviourModel.ProvideCooldown() / Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, toPosition, _progress);
        }
        
        public Vector2 toPosition;
        private void FixedUpdate()
        {
            Move();
            
        }

        private void Rotate()
        {
            var attackArea = transform.GetChild(0).gameObject;
            if (_moveDirection.x > 0)
            {
                _sr.flipX = false;
                attackArea.transform.rotation = new Quaternion(0f, 0f, 0.70711f, -0.70711f);
            }
            else if (_moveDirection.x < 0)
            {
                _sr.flipX = true;
                attackArea.transform.rotation = new Quaternion(0f, 0f, 0.70711f, 0.70711f);
            }
            else if (_moveDirection.y > 0)
                attackArea.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
            else if (_moveDirection.y < 0)
                attackArea.transform.rotation = new Quaternion(0f, 0f, 1, 0f);
        }

        private void CheckCollision()
        {
            _collision = Physics2D.BoxCast(transform.position, _collider.size, 0, new Vector2(_moveDirection.x, _moveDirection.y),
                Mathf.Abs(_moveDirection.x) + Mathf.Abs(_moveDirection.y),
                LayerMask.GetMask("Actor", "Blocking"));
        }

        private void ChangePosition()
        {
            if (_moveDirection.x != 0)
                toPosition = new Vector2(transform.position.x + _moveDirection.x, transform.position.y);
            else toPosition = new Vector2(transform.position.x, transform.position.y + _moveDirection.y);
            //transform.Translate(_moveDirection.x, _moveDirection.y, 0);
            _behaviourModel.ChangePlayerPosition(transform.position.x, transform.position.y);
            timer = 0;
        }

        public void Move()
        {
            
            timer += Time.deltaTime;
            if (timer < _behaviourModel.ProvideCooldown()) return;

            Rotate();
            CheckCollision();

            if (_moveDirection != Vector2.zero && !_collision.collider)
            {
                
                ChangePosition();
                _animator.SetTrigger("IsMoving");
            }
        }

        public void TeleportToTileCoordinates(Vector2Int coordinates)
        {
            Vector3 position = CoordinateManipulation.ToWorldCoord(coordinates);
            toPosition = position;
            transform.position = position;
            _behaviourModel.TeleportToCoordinates(position.x, position.y);
        }

        public void SetLadderPos(Vector2Int floor)
        {
            ladderPos = CoordinateManipulation.ToWorldCoord(floor);
        }
    }
}