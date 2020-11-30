using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textures : MonoBehaviour
{
    private float _collisionForceWithoutDamage = 7.5f;
    private float _damage = 0.012f;

    public float CollisionForceWithoutDamage => _collisionForceWithoutDamage;

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
