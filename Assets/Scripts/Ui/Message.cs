using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] private float _showingTime;
    [SerializeField] private float _fadeTime;
    [SerializeField] private float _iconScale;
    [SerializeField] private Image _icon;

    private TMP_Text _message;
    private bool _timer;
    private float _elapsedTime;
    private RectTransform _rectTransform;
    private bool _isBusy = false;
    private Vector3 _iconPosition;

    private void Start()
    {
        _message = GetComponent<TMP_Text>();
        _rectTransform = _icon.GetComponent<RectTransform>();

        _iconPosition = _icon.rectTransform.localPosition;
    }

    private void DissolveMessage()
    {
        _message.DOFade(0, _fadeTime);
        _icon.DOFade(0, _fadeTime);
        _isBusy = false;
    }

    private void Update()
    {
        if (_timer)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _showingTime)
            {
                DissolveMessage();
                _timer = false;
                _elapsedTime = 0;
            }
        }
    }

    public void ShowMessage(string text, Sprite sprite)
    {
        if (!_isBusy)
        {
            _message.text = text;
            _icon.sprite = sprite;
            _icon.rectTransform.localScale = new Vector3(_iconScale, _iconScale, _iconScale);
            _icon.rectTransform.localPosition = _iconPosition;

            _message.DOFade(1, _fadeTime);
            _icon.DOFade(1, _fadeTime);

            _timer = true;
            _isBusy = true;
        }
    }
}
