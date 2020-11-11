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

    private Rigidbody2D _rigidbody2D;
    private Vector3 _currentCheckPoint;
    private float _elapsedTime = 0;
    private bool _isEmptyFuel = false;
    private Animator _animator;


    public bool IsDead { get; private set; }
    public bool _isFreezedPosition { get; private set; }
    public int StarsCollected { get; private set; }

    private void Start()
    {
        _healthBar.value = _health;
        _currentCheckPoint = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        IsDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CheckPoint>())
            _currentCheckPoint = collision.transform.position;
        if (collision.GetComponent<Star>())
            StarsCollected++;
    }

    private void Update()
    {
        if (IsDead)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _timeBeforeRespawn / 2 && !_isFreezedPosition && !_isEmptyFuel)
                FreezePosition();
            if (_elapsedTime >= _timeBeforeRespawn)
            {
                Respawn();
                _elapsedTime = 0;
            }
        }
    }

    private void Respawn()
    {
        IsDead = false;
        _animator.SetBool("IsDead", IsDead);
        _isFreezedPosition = false;

        transform.rotation = Quaternion.identity;
        _rigidbody2D.constraints = RigidbodyConstraints2D.None;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.position = _currentCheckPoint;

        AddHealth(1);
        GetComponent<RocketMover>().AddFuel(1);
    }

    private void FreezePosition()
    {
        _isFreezedPosition = true;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Die(bool isEmptyFuel)
    {
        IsDead = true;
        _animator.SetBool("IsDead", IsDead);
        _isEmptyFuel = isEmptyFuel;
    }

    public void AddHealth(float quantity)
    {
        if (quantity > 0)
            _healthBar.DOValue(_healthBar.value + quantity, _healthBarAnimationSpeed);
    }

    public void TakeDamage(float damage)
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

    public void ShowMessage(string message)
    {
        Debug.Log(message);
    }
}
