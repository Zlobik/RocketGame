using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Sprite _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>() && collision.gameObject.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            rocketMessage.ShowMessage("star collected", _sprite);
            gameObject.SetActive(false);
        }
    }
}
