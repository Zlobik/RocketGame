using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
    [SerializeField] private float _capacity = 0.8f;

    private Sprite _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<RocketMover>(out RocketMover rocketMover) && collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            rocketMover.AddFuel(_capacity);
            rocketMessage.ShowMessage("fuel collected", _sprite);
            gameObject.SetActive(false);
            gameObject.GetComponentInParent<CollectItemsRespawner>().SetRocket(collision.GetComponent<Rocket>());
        }
    }
}
