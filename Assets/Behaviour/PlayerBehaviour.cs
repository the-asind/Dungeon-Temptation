using _Scripts;
using _Scripts.DungeonGenerator;
using DungeonCreature.BehaviourModel;
using Unity.VisualScripting;
using UnityEngine;

namespace DungeonCreature
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public PlayerBehaviourModel _behaviourModel;
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
            _behaviourModel = new PlayerBehaviourModel(transform.position.x, transform.position.y);
            _animator = GetComponent<Animator>();
            _collider = GetComponent<BoxCollider2D>();
            _sr = GetComponent<SpriteRenderer>();
            _attackArea = GetComponent<AttackArea>();
            _room = GameObject.Find("RoomDungeonGenerator").GetComponent<RoomDungeonGenerator>();
            _behaviourModel.PositionChanged += OnPositionChanged;
            _behaviourModel.Die += OnDie;
        }

        private void OnDie()
        {
            Destroy(this);
        }
        private void OnPositionChanged()
        {
            Position position = _behaviourModel.ProvidePosition();
            transform.Translate(position.X, position.Y, 0);
        }
        private void Update()
        {
            _moveDirection.x = Input.GetAxisRaw("Horizontal");
            _moveDirection.y = Input.GetAxisRaw("Vertical");

            if (transform.position == ladderPos) _room.GenerateDungeon();
        }

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
            _behaviourModel.ChangePlayerPosition(_moveDirection.x + transform.position.x, _moveDirection.y + transform.position.y);
            transform.position = new Vector3(_behaviourModel.Player.Position.X, _behaviourModel.Player.Position.Y, 0);
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
            _behaviourModel.TeleportToCoordinates(position.x, position.y);
            transform.position = position;
        }

        public void SetLadderPos(Vector2Int floor)
        {
            ladderPos = CoordinateManipulation.ToWorldCoord(floor);
        }
    }
}