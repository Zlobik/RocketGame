using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.rotation += _rotateSpeed * Time.deltaTime;
    }
}
