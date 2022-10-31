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
    private RaycastHit2D[] _result = new RaycastHit2D[1];
    private float _xAxis;
    private bool _haveToJump;

    static readonly int Run = Animator.StringToHash("Player Run");
    static readonly int Idle = Animator.StringToHash("Player Idle");
    static readonly int Jumping = Animator.StringToHash("Player Jump");

    private void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _haveToJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (_xAxis != 0)
        {
            _rg2D.velocity = new Vector2(_xAxis * _speed, _rg2D.velocity.y);
            _spriteR.flipX = _xAxis < 0;
            _animator.CrossFade(Run, 0.01f);
        }
        else
        {
            _rg2D.velocity = new Vector2(0, _rg2D.velocity.y); ;

            if (IsGrounded() == false)
            {
                _animator.CrossFade(Jumping, 0.01f);
            }
            else
            {
                _animator.CrossFade(Idle, 0.01f);
            }
        }

        if (_haveToJump)
        {
            _rg2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _haveToJump = false;
        }

    }

    private bool IsGrounded()
    {
        int collisionCount = _rg2D.Cast(Vector2.down, _result, _distanceToCheck);

        return collisionCount > 0;
    }
}