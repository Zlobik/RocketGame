using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCardDoor : MonoBehaviour
{
    [SerializeField] private float _openningOffset;
    [SerializeField] private float _openenningTime;
    [SerializeField] private Sprite _blueCardSprite;

    private bool _isDoorOpenned = false;
    private float _elapsedTime = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            if (rocketMessage.HaveBlueCard)
                OpenDoor();
            else
                rocketMessage.ShowMessage("NEED BLUE CARD", _blueCardSprite);
        }
    }

    private void OpenDoor()
    {
        transform.DOMoveY(transform.position.y + _openningOffset, _openenningTime);

        _isDoorOpenned = true;
    }

    private void Update()
    {
        if (_isDoorOpenned)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _openenningTime)
                gameObject.SetActive(false);
        }
    }
}
