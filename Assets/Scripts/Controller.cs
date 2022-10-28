using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Controller : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private float _speed = 2f;

    private Rigidbody2D _rg2D;
    private RaycastHit2D[] _result = new RaycastHit2D[1];
    private Animator _animator;
    private SpriteRenderer _spriteR;
    private float _distanceToCheck = 0.1f;
    private float _horizontal;

    static readonly int move = Animator.StringToHash("Move");

    void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Jump();
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
            _spriteR.flipX = _horizontal < 0;
            _animator.SetFloat(move, Mathf.Abs(_horizontal));
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rg2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}