using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Controller : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private float _speed = 2f;

    private Rigidbody2D _rg2D;
    private RaycastHit2D[] _result = new RaycastHit2D [1];
    private float _distanceToCheck = 0.1f;
    private float _horizontal;

    void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rg2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
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
}
