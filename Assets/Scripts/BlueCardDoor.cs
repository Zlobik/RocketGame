using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCardDoor : MonoBehaviour
{
    [SerializeField] private float _openningOffset;
    [SerializeField] private float _openenningSpeed;

    private bool _isDoorOpenned = false;
    private float _elapsedTime = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            if (rocketMessage.HaveBlueCard)
                OpenDoor();
        }
    }

    private void OpenDoor()
    {
        transform.DOMoveY(transform.position.y + _openningOffset, _openenningSpeed);
        gameObject.SetActive(false);


        _isDoorOpenned = true;
    }

    private void Update()
    {
        if (_isDoorOpenned)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _openenningSpeed)
                gameObject.SetActive(false);
        }
    }
}
