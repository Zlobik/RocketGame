using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class RocketRotationSlider : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool _timer = false;
    private float _elapsedTime = 0;
    private Slider _slider;

    public float SliderValue { get; private set; } = 0;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void OnValueChanged()
    {
        if (_slider.value > 0.65f)
            SliderValue = _slider.value - 0.15f;
        else if (_slider.value < -0.65f)
            SliderValue = _slider.value + 0.15f;
        else
            SliderValue = _slider.value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _timer = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _elapsedTime = 0;
        _timer = true;
    }

    private void FixedUpdate()
    {
        if (_timer)
        {
            _elapsedTime += Time.fixedDeltaTime;

            if (_elapsedTime > 0.075f)
            {
                _slider.DOValue(0, 0.15f);

                _timer = false;
                _elapsedTime = 0;

                if (_slider.value == 0)
                    SliderValue = 0;
            }
        }
    }
}
