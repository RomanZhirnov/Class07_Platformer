using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Controller : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rg2D;
    private float _speed = 2f;
    private float _jumpForce = 10f;
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
            _rg2D.velocity = new Vector2(_rg2D.velocity.x, _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        _rg2D.velocity = new Vector2(_horizontal * _speed, _rg2D.velocity.y);      
    }


    private bool IsGrounded()
    {
        //return Physics2D.OverlapCircle(_groundCheck.position, _distanceToCheck, _groundLayer);

        //RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, _distanceToCheck, _groundLayer);

        if (Physics2D.Raycast(_groundCheck.position, Vector2.down, _distanceToCheck, _groundLayer))
        {
            return true;
        }

        return false;
    }
}
