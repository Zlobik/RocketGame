using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    [SerializeField] private float _capacity = 0.8f;
    [SerializeField] private ParticleSystem _collectEffect;

    private ParticleSystem _effect;
    private Sprite _sprite;
    private bool _isSetRocket = false;
    private bool _isCollected;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out Rocket rocket) && collision.gameObject.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            _isCollected = true;

            GetComponent<SpriteRenderer>().sprite = null;
            rocket.AddHealth(_capacity);
            _effect = Instantiate(_collectEffect, transform);

            if (!_isSetRocket)
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
