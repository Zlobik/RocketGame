using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
    [SerializeField] private float _capacity = 0.8f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<RocketMover>(out RocketMover rocketMover))
        {
            rocketMover.AddFuel(_capacity);
            gameObject.SetActive(false);

            gameObject.GetComponentInParent<CollectItemsRespawner>().SetRocket(collision.GetComponent<Rocket>());
        }
    }
}
