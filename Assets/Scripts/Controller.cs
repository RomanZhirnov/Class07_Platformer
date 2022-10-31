using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Controller : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private float _speed = 2f;

    private Rigidbody2D _rg2D;
    private Animator _animator;
    private SpriteRenderer _spriteR;
    private float _distanceToCheck = 0.1f;
    private float _horizontal;
    private RaycastHit2D[] _result = new RaycastHit2D[1];

    static readonly int Run = Animator.StringToHash("Player Run");
    static readonly int Idle = Animator.StringToHash("Player Idle");
    static readonly int Jumping = Animator.StringToHash("Player Jump");

    void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Jump();
        Move();
        _rg2D.velocity = new Vector2(_horizontal * _speed, _rg2D.velocity.y);
    }

    private bool IsGrounded()
    {
        int collisionCount = _rg2D.Cast(Vector2.down, _result, _distanceToCheck);

        if (collisionCount != 0)
        {
            return true;
        }

        return false;
    }

    private void Move()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (IsGrounded())
        {
            if (_horizontal != 0)
            {
                _spriteR.flipX = _horizontal < 0;
                _animator.CrossFade(Run, 0.1f);
            }
            else 
            {
                _animator.CrossFade(Idle, 0.1f);
            }
        }     
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _animator.CrossFade(Jumping, 0.1f);
            _rg2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}