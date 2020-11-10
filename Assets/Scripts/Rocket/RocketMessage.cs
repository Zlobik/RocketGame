using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketMessage : MonoBehaviour
{
    [SerializeField] private Message _message;
    [SerializeField] private float _fadeSpeed;

    private bool _timer = false;
    private float _elapsedTime = 0;

    public bool HaveBlueCard { get; private set; }

    private void Start()
    {
        HaveBlueCard = false;
    }

    public void ShowMessage(string text, Sprite sprite)
    {
        if (text == "blue card collected")
            HaveBlueCard = true;

        _message.ShowMessage(text, sprite);
    }
}
