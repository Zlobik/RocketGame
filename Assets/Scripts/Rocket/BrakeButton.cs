using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RocketMover _rocketMover;

    private Rigidbody2D _rigidbody2D;
    private bool _isPressed = false;

    private void Start ()
    {
        _rigidbody2D = _rocketMover.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate ()
    {
        if (_isPressed)
        {
            _rigidbody2D.AddForce((-_rocketMover.transform.up * _rocketMover.UpForce / 2) * Time.fixedDeltaTime);
        }
    }

    void IPointerDownHandler.OnPointerDown (PointerEventData eventData)
    {
        _isPressed = true;
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        _isPressed = false;
    }
}
