using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemsRespawner : MonoBehaviour
{
    private Rocket _rocket;
    private Transform[] _items;

    private bool _isRespawning = false;

    private void Start()
    {
        _items = gameObject.GetComponentsInChildren<Transform>();
    }

    public void RespawnCollectingItems()
    {
        _isRespawning = true;

        for (int i = 0; i < _items.Length; i++)
            _items[i].gameObject.SetActive(true);
    }

    public void SetRocket(Rocket rocket)
    {
        if (_rocket == null)
            _rocket = rocket;
    }

    private void FixedUpdate()
    {
        if (_rocket != null)
        {
            if (_rocket.IsDead && !_isRespawning)
                RespawnCollectingItems();
            if (!_rocket.IsDead && _isRespawning)
                _isRespawning = false;
        }
    }
}
