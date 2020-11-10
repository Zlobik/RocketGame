using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCard : MonoBehaviour
{
    private Sprite _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            rocketMessage.ShowMessage("blue card collected", _sprite);
            gameObject.SetActive(false);
        }
    }
}
