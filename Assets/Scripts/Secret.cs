using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            rocketMessage.ShowMessage("You found a secret", _sprite);
        }
    }
}
