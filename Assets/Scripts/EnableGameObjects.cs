using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;

    private void Start()
    {
        for (int i = 0; i < _gameObjects.Length; i++)
            _gameObjects[i].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            for (int i = 0; i < _gameObjects.Length; i++)
                _gameObjects[i].SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
