using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private Transform _effectTransform;

    private ParticleSystem _effect;

    private Rocket _rocket;

    private void Start()
    {
        _rocket = GetComponent<Rocket>();

        //_effect = Instantiate(_collisionEffect, transform);
        //_effect.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Textures textures = new Textures();

        if (collision.relativeVelocity.magnitude > textures.CollisionForceWithoutDamage)
            Instantiate(_collisionEffect, _effectTransform).gameObject.SetActive(true);


        if (collision.gameObject.GetComponent<Rocket>() )
        {
            _effect.transform.position = transform.position;
            _effect.gameObject.SetActive(true);
            _effect.Play();
        }
    }
}
