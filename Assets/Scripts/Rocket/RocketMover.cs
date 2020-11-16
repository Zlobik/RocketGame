using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketMover : MonoBehaviour
{
    [SerializeField] private float _upForce;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private ControlButton _upButton;
    [SerializeField] private ControlButton _leftButton;
    [SerializeField] private ControlButton _rightButton;

    [SerializeField] private Slider _fuelBar;
    [SerializeField] private float _fuelBarAnimationSpeed;
    [SerializeField] private float _upConsuption;
    [SerializeField] private float _idleConsuption;

    private Rigidbody2D _rigidbody2D;
    private Rocket _rocket;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rocket = GetComponent<Rocket>();
        _animator = GetComponent<Animator>();
    }

    private void MoveUp()
    {
        if (!_animator.GetBool("IsPressedUpButton"))
            _animator.SetBool("IsPressedUpButton", true);

        _rigidbody2D.AddForce(transform.up * _upForce * Time.deltaTime, ForceMode2D.Force);
        BurnFuel(_upConsuption);
    }

    private void Rotate(float rotateSpeed)
    {
        transform.Rotate(0, 0, (transform.rotation.z + rotateSpeed) * Time.deltaTime);
        BurnFuel(_idleConsuption);
    }

    private void FixedUpdate()
    {
        if (!_rocket.IsDead)
        {
            if (Input.GetKey(KeyCode.W) || _upButton.IsPressed)
                MoveUp();
            if (Input.GetKey(KeyCode.A) || _leftButton.IsPressed)
                Rotate(_rotateSpeed);
            if (Input.GetKey(KeyCode.D) || _rightButton.IsPressed)
                Rotate(-_rotateSpeed);
            if (!_upButton.IsPressed && _animator.GetBool("IsPressedUpButton"))
                _animator.SetBool("IsPressedUpButton", false);
            else
                BurnFuel(_idleConsuption);
        }
    }

    private void BurnFuel(float quantity)
    {
        _fuelBar.value -= quantity * Time.deltaTime;

        if (_fuelBar.value == 0)
            _rocket.Die(true);
    }

    public void AddFuel(float quantity)
    {
        _fuelBar.DOValue(_fuelBar.value + quantity, _fuelBarAnimationSpeed);
    }
}
