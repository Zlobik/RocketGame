using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPress : MonoBehaviour
{
    [SerializeField] private float _offsetDepthY;
    [SerializeField] private float _goBackSpeed;
    [SerializeField] private float _compressSpeed;
    [SerializeField] private float _damage;

    private Vector3 _currentPosition;
    private bool _isCompress = true;
    private float _time;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out Rocket rocket))
            rocket.TakeDamage(_damage);
    }

    private void MoveBackY()
    {
        transform.DOMoveY(_currentPosition.y, _goBackSpeed);
    }

    private void Update()
    {
        if (_isCompress)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_currentPosition.x, _currentPosition.y - _offsetDepthY, _currentPosition.z), _compressSpeed * Time.deltaTime);

            if (transform.position.y <= _currentPosition.y - _offsetDepthY)
            {
                MoveBackY();
                _isCompress = false;
            }
        }
        else if (!_isCompress)
        {
            _time += Time.deltaTime;

            if (_time >= _goBackSpeed)
            {
                _isCompress = true;
                _time = 0;
            }
        }
    }
}