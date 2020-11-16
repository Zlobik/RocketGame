using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private Transform _effectTransform;

    private ParticleSystem _effect;
    private float _elapsedTime;
    private bool _timer;
    private Rocket _rocket;
    private Textures _textures;

    private void Start()
    {
        _effect = Instantiate(_collisionEffect, _effectTransform);
        _effect.gameObject.SetActive(false);
        _rocket = GetComponent<Rocket>();
        _textures = new Textures();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<Textures>() || collision.gameObject.GetComponent<Thorns>() || collision.gameObject.GetComponent<DeathPress>())
        {
            if (collision.relativeVelocity.magnitude > _textures.CollisionForceWithoutDamage && !_timer && !_rocket.IsDead)
            {
                _effect.gameObject.SetActive(true);
                _timer = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_timer)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= 0.5f)
            {
                _timer = false;
                _elapsedTime = 0;
            }
        }
    }
}
