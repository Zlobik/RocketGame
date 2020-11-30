using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _timeBeforeRespawn;
    [SerializeField] private float _healthBarAnimationSpeed;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private CameraFollow _camera;

    private Rigidbody2D _rigidbody2D;
    private float _elapsedTime = 0;
    private bool _isEmptyFuel = false;
    private Animator _animator;
    private RocketMover _rocketMover;
    private AudioSource _audioSource;
    private CapsuleCollider2D _capsuleCollider2D;

    public bool IsDead { get; private set; } = false;
    public int StarsCollected { get; private set; } = 0;
    public Vector3 CurrentCheckPoint { get; private set; }

    private void Start ()
    {
        _healthBar.value = _health;
        CurrentCheckPoint = transform.position;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _rocketMover = GetComponent<RocketMover>();
        _audioSource = GetComponent<AudioSource>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        _camera.SetNewCheckPoint(new Vector3(transform.position.x, transform.position.y, -10));
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.GetComponent<CheckPoint>())
        {
            CurrentCheckPoint = collision.transform.position;
            _camera.SetNewCheckPoint(new Vector3(collision.transform.position.x, collision.transform.position.y, -10));
        }
        else if (collision.GetComponent<Star>())
            StarsCollected++;
    }

    private void Update ()
    {
        if (IsDead)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _timeBeforeRespawn)
            {
                Respawn();
                _elapsedTime = 0;
            }
        }
    }

    private void Respawn ()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        _rigidbody2D.constraints = RigidbodyConstraints2D.None;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _capsuleCollider2D.enabled = true;

        IsDead = false;
        _animator.SetBool("IsDead", IsDead);

        transform.rotation = Quaternion.identity;
        transform.position = CurrentCheckPoint;
        GetComponent<SpriteRenderer>().DOFade(255, 1.65f);

        AddHealth(1);
        _rocketMover.AddFuel(1);
    }

    public void Die (bool isEmptyFuel)
    {
        _audioSource.clip = _explosionSound;
        _audioSource.Play();

        _isEmptyFuel = isEmptyFuel;
        IsDead = true;
        _capsuleCollider2D.enabled = false;

        if (!_isEmptyFuel)
            _animator.SetBool("IsDead", IsDead);

        _animator.SetBool("IsPressedUpButton", false);

        GetComponent<SpriteRenderer>().DOFade(0, 0.35f);
    }

    public void AddHealth (float quantity)
    {
        if (quantity > 0)
            _healthBar.DOValue(_healthBar.value + quantity, _healthBarAnimationSpeed);

    }

    public void TakeDamage (float damage)
    {
        if (!IsDead)
        {
            if (_healthBar.value - damage > 0 && damage > 0)
                _healthBar.DOValue(_healthBar.value - damage, _healthBarAnimationSpeed);
            else
            {
                _healthBar.DOValue(0, _healthBarAnimationSpeed);
                Die(false);
            }
        }
    }
}
