using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    [SerializeField] private float _capacity = 0.8f;
    [SerializeField] private ParticleSystem _collectEffect;
    [SerializeField] private bool _needRespawn = true;

    private ParticleSystem _effect;
    private SpriteRenderer _renderer;
    private Sprite _sprite;
    private bool _isSetRocket = false;
    private bool _isCollected;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _sprite = _renderer.sprite;
        _effect = Instantiate(_collectEffect, transform);
        _effect.gameObject.SetActive(false);
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnDisable()
    {
        if (_needRespawn)
        {
            _isCollected = false;

            if (_renderer.sprite == null)
                _renderer.sprite = _sprite;

            _boxCollider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out Rocket rocket) && collision.gameObject.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            _isCollected = true;
            _boxCollider.enabled = false;

            GetComponent<SpriteRenderer>().sprite = null;
            rocket.AddHealth(_capacity);
            _effect.gameObject.SetActive(true);

            if (!_isSetRocket && _needRespawn)
            {
                _isSetRocket = true;
                GetComponentInParent<CollectItemsRespawner>().SetRocket(rocket);
            }

            rocketMessage.ShowMessage("repair kit collected", _sprite);
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
