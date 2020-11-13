using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private float _openningSpeed;
    [SerializeField] private float _openningOffset;
    [SerializeField] private Transform _greenLight;
    [SerializeField] private Transform _door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rocket>(out Rocket rocket))
            OpenDoor();
    }

    private void OpenDoor()
    {
        _door.DOMoveX(_door.position.x + _openningOffset, _openningSpeed);
        _greenLight.gameObject.SetActive(true);
    }
}
