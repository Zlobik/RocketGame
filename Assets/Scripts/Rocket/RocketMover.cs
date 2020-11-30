using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketMover : MonoBehaviour
{
    [SerializeField] private float _upForce;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private AudioClip _upSound;

    [SerializeField] private ControlButton _upButton;
    [SerializeField] private ControlButton _leftButton;
    [SerializeField] private ControlButton _rightButton;
    [SerializeField] private bool _usingRotationSlider = false;
    [SerializeField] private RocketRotationSlider _rotationSlider;

    [SerializeField] private Slider _fuelBar;
    [SerializeField] private float _fuelBarAnimationSpeed;
    [SerializeField] private float _upConsuption;
    [SerializeField] private float _idleConsuption;

    private Rigidbody2D _rigidbody2D;
    private Rocket _rocket;
    private Animator _animator;
    private AudioSource _audioSource;


    public float UpForce => _upForce;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rocket = GetComponent<Rocket>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void MoveUp()
    {
        if (!_animator.GetBool("IsPressedUpButton"))
            _animator.SetBool("IsPressedUpButton", true);

        _rigidbody2D.AddForce(transform.up * _upForce * Time.fixedDeltaTime, ForceMode2D.Force);
        BurnFuel(_upConsuption);

        if (!_audioSource.isPlaying)
        {
            if (_audioSource.clip != _upSound)
                _audioSource.clip = _upSound;

            _audioSource.Play();
        }
    }

    public void UsingRotationSlider(bool isUsing)
    {
        _usingRotationSlider = isUsing;
    }

    public void Rotate(float rotateSpeed)
    {
        _rigidbody2D.rotation += rotateSpeed * Time.fixedDeltaTime;

        BurnFuel(_idleConsuption);
    }

    private void FixedUpdate()
    {
        if (!_rocket.IsDead)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || _upButton.IsPressed )
                MoveUp();
            if (!_usingRotationSlider)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || _leftButton.IsPressed)
                    Rotate(_rotateSpeed);
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || _rightButton.IsPressed)
                    Rotate(-_rotateSpeed);
            }
            else
            {
                Rotate(-_rotationSlider.SliderValue * _rotateSpeed);
            }

            if (!_upButton.IsPressed && _animator.GetBool("IsPressedUpButton"))
            {
                _audioSource.Stop();
                _animator.SetBool("IsPressedUpButton", false);
            }
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
