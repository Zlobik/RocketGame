using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    [SerializeField] private float _capacity = 0.8f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Rocket>(out Rocket rocket))
        {
            rocket.AddHealth(_capacity);
            gameObject.SetActive(false);

            gameObject.GetComponentInParent<CollectItemsRespawner>().SetRocket(rocket);
        }
    }
}
