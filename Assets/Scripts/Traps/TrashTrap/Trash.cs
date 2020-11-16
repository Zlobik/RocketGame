using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;

    private float _speed;

    private void Start()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rocket>(out Rocket rocket))
        {
            if (_damage > 0)
                rocket.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - 10, transform.position.z), _speed * Time.deltaTime);
    }
}
