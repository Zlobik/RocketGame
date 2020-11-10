using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private bool _isGorizontal;
    [SerializeField] private float _doorOffset;
    [SerializeField] private float _openningSpeed;
    [SerializeField] private float _closingTime;
    [SerializeField] private float _timeBeforeDoorClosing;

    private Vector3 _closedDoorPosition;
    private bool _isRocketOnPlate = false;
    private float _elapsedTime;
    private bool _timer;
    private float _currentPlatePosition;

    private void Start()
    {
        _closedDoorPosition = _door.position;
        _currentPlatePosition = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rocket>())
        {
            _isRocketOnPlate = true;
            _elapsedTime = 0;
            _timer = false;

            transform.DOMoveY(_currentPlatePosition - 0.1f, 0.3f);
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isRocketOnPlate = false;
        _timer = true;
        transform.DOKill();
        transform.DOMoveY(_currentPlatePosition, 0.2f);
    }

    private void Update()
    {
        if (_isRocketOnPlate)
            OpenDoor();
        if (_timer)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _timeBeforeDoorClosing)
            {
                _elapsedTime = 0;
                _timer = false;
                CloseDoor();
            }
        }
    }

    private void CloseDoor()
    {
        if (_isGorizontal)
            _door.DOMove(_closedDoorPosition, _closingTime);
    }

    private void OpenDoor()
    {
        if (_isGorizontal)
        {
            if (_door.position.x <= _closedDoorPosition.x - _doorOffset)
                _door.position = Vector3.MoveTowards(_door.position, new Vector3(_door.position.x + _doorOffset, _door.position.y, _door.position.z), _openningSpeed * Time.deltaTime);
        }
        if (!_isGorizontal)
            _door.position = Vector3.MoveTowards(_door.position, new Vector3(_door.position.x, _door.position.y + _doorOffset, _door.position.z), _openningSpeed * Time.deltaTime);
    }

}
