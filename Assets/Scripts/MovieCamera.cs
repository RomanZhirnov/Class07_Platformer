using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovieCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    void Update()
    {
        _targetPosition.x = _playerPosition.position.x;

        transform.position = _targetPosition;
    }
}
