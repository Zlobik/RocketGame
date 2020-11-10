using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    [SerializeField] private float _capacity = 0.8f;

    private Sprite _sprite;
    private bool _isSetRocket = false;


    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out Rocket rocket) && collision.gameObject.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            if (!_isSetRocket)
            {
                _isSetRocket = true;
                gameObject.GetComponentInParent<CollectItemsRespawner>().SetRocket(rocket);
            }

            rocket.AddHealth(_capacity);
            rocketMessage.ShowMessage("repair kit collected", _sprite);
            gameObject.SetActive(false);
        }
    }
}
