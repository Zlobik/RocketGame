using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _redLight;
    [SerializeField] private Sprite _greenLight;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ParticleSystem _passiveEffect;

    private int count = 0;
    private ParticleSystem _effect;
    private CircleCollider2D _circleCollider2D;

    private void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _effect = Instantiate(_passiveEffect, transform);
        _effect.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>() && collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            count++;

            if (count >= 1)
            {
                rocketMessage.ShowMessage("check point reached", _sprite);
                _redLight.sprite = _greenLight;
                _circleCollider2D.enabled = false;
                _effect.gameObject.SetActive(false);
                transform.GetChild(0).gameObject.GetComponent<PointEffector2D>().enabled = false;
            }
        }
    }
}
