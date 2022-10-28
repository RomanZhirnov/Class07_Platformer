using System.Collections;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 1;

    private Coroutine _moving;

    void Start()
    {
        _path = GetComponentInChildren<Path>().transform;

        Vector3[] _points = new Vector3[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i).transform.position;
        }

        if (_points.Length > 0)
        {
            _moving = StartCoroutine(Moving(_points));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
            }
        }
    }

    private IEnumerator Moving(Vector3[] points)
    {
        int _targetIndex = 0;

        while (true)
        {
            if (transform.position != points[_targetIndex])
            {
                transform.position = Vector2.MoveTowards(transform.position, points[_targetIndex], _speed * Time.deltaTime);
            }

            if (transform.position == points[_targetIndex])
            {
                _targetIndex++;

                if (_targetIndex == points.Length)
                {
                    Array.Reverse(points);
                    _targetIndex = 0;
                }
            }

            yield return null;
        }
    }

}
