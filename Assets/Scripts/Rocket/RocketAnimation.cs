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


    private void Start()
    {
        _effect = Instantiate(_collisionEffect, _effectTransform);
        _effect.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Textures textures = new Textures();

        if (collision.relativeVelocity.magnitude > textures.CollisionForceWithoutDamage && !_timer)
        {
            _effect.gameObject.SetActive(true);
            _timer = true;
        }
    }

    private void FixedUpdate()
    {
        if (_timer)
        {
            _elapsedTime += Time.deltaTime;

            if(_elapsedTime >= 0.5f)
            {
                _timer = false;
                _elapsedTime = 0;
            }
        }
    }
}
