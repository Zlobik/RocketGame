using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingThorns : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);

        if(transform.position == _points[_currentPoint].position)
        {
            _currentPoint++;

            if (_currentPoint == _points.Length)
                _currentPoint = 0;
        }
    }
}
