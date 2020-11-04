using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textures : MonoBehaviour
{
    [SerializeField] private float _damage = 0.015f;
    [SerializeField] private float _collisionForceWithoutDamage = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out Rocket rocket))
        {
            float collisionForce = collision.relativeVelocity.magnitude;

            if (collisionForce >= _collisionForceWithoutDamage)
                rocket.TakeDamage(_damage * collisionForce);
        }
    }
}
