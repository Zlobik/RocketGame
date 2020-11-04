using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _redLight;
    [SerializeField] private Sprite _greenLight;

    private CircleCollider2D _circleCollider2D;

    private void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            _redLight.sprite = _greenLight;
            _circleCollider2D.enabled = false;
        }
    }
}
