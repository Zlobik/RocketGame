using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
    [SerializeField] private float _capacity = 0.8f;
    [SerializeField] private ParticleSystem _collectEffect;
    [SerializeField] private bool _needRespawn = true;

    private ParticleSystem _effect;
    private bool _isCollected;
    private Sprite _sprite;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _sprite = _renderer.sprite;
        _effect = Instantiate(_collectEffect, transform);
        _effect.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (_needRespawn)
        {
            _isCollected = false;
            if (_renderer.sprite == null)
                _renderer.sprite = _sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RocketMover>(out RocketMover rocketMover) && collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            _isCollected = true;
            _effect.gameObject.SetActive(true);

            _renderer.sprite = null;
            rocketMover.AddFuel(_capacity);

            if (_needRespawn)
                gameObject.GetComponentInParent<CollectItemsRespawner>().SetRocket(collision.GetComponent<Rocket>());

            rocketMessage.ShowMessage("fuel collected", _sprite);
        }
    }

    private void FixedUpdate()
    {
        if (_isCollected)
        {
            if (!_effect.IsAlive())
            {
                _effect.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
