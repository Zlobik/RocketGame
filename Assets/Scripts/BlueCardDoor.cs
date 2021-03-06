﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCardDoor : MonoBehaviour
{
    [SerializeField] private float _openningOffset;
    [SerializeField] private float _openenningTime;
    [SerializeField] private Sprite _blueCardSprite;
    [SerializeField] private bool _isOpenningGorizontal = false;

    private bool _isDoorOpenned = false;
    private float _elapsedTime = 0;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            if (rocketMessage.HaveBlueCard)
                OpenDoor();
            else
                rocketMessage.ShowMessage("NEED BLUE CARD", _blueCardSprite);
        }
    }

    private void OpenDoor ()
    {
        if (!_isOpenningGorizontal)
            transform.DOMoveY(transform.localPosition.y + _openningOffset, _openenningTime);
        else
            transform.DOMoveX(transform.localPosition.x + _openningOffset, _openenningTime);

        _isDoorOpenned = true;
    }

    private void Update ()
    {
        if (_isDoorOpenned)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _openenningTime)
                gameObject.SetActive(false);
        }
    }
}
