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
    [SerializeField] private float _imageScale;

    private TMP_Text _message;
    private bool _timer;
    private float _elapsedTime;
    private RectTransform _rectTransform;
    private Image _image;

    private void Start()
    {
        _message = GetComponent<TMP_Text>();
        _image = GetComponentInChildren<Image>();
        _rectTransform = _image.GetComponent<RectTransform>();
    }

    private void DissolveMessage()
    {
        _message.DOFade(0, _fadeTime);
        _image.DOFade(0, _fadeTime);
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
        _message.text = text;
        _image.sprite = sprite;
        _image.SetNativeSize();
        _rectTransform.localScale = new Vector3(_imageScale, _imageScale, 0);

        _message.DOFade(1, _showingTime);
        _image.DOFade(1, _showingTime);

        _timer = true;
    }
}
