using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collectEffect;

    private Sprite _sprite;
    private bool _isCollected = false;
    private ParticleSystem _effect;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>() && collision.gameObject.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            _isCollected = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = null;

            _effect = Instantiate(_collectEffect, transform);
            _effect.gameObject.transform.Rotate(transform.localScale, 0.1f);

            rocketMessage.ShowMessage("star collected", _sprite);
        }
    }

    private void FixedUpdate()
    {
        if (_isCollected)
        {
            if (!_effect.IsAlive())
                gameObject.SetActive(false);
        }
    }
}
