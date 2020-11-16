using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGamobjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    [SerializeField] private GameObject _unvisibleDoor;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            for (int i = 0; i < _gameObjects.Length; i++)
                _gameObjects[i].SetActive(false);

            _unvisibleDoor.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
