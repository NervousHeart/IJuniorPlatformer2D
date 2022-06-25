using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private int _currentPoint;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();   
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
    private void Update()
    {
        Patrol();
    }
    private void Patrol()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;
            ChangeFlip();
            if (_currentPoint >= _points.Length)
                _currentPoint = 0;
        }
    }

    private void ChangeFlip()
    {
        if(_spriteRenderer.flipX)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
