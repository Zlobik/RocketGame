using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
    [SerializeField] private float _capacity = 0.8f;
    [SerializeField] private ParticleSystem _collectEffect;

    private ParticleSystem _effect;
    private bool _isCollected;
    private Sprite _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<RocketMover>(out RocketMover rocketMover) && collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            _isCollected = true;

            GetComponent<SpriteRenderer>().sprite = null;
            _effect = Instantiate(_collectEffect, transform);
            rocketMover.AddFuel(_capacity);

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
