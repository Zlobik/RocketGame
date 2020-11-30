using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldOfViewSlider : MonoBehaviour
{
    [SerializeField] private float _cameraSize;

    private Slider _slider;
    private string _saveName = "FieldOfView";

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        if (!PlayerPrefs.HasKey(_saveName))
            PlayerPrefs.SetFloat(_saveName, _slider.value * _cameraSize);

        _slider.value = PlayerPrefs.GetFloat(_saveName) / _cameraSize;
    }

    public void OnValueChanged()
    {
        if (_slider.value >= 0.4f)
            PlayerPrefs.SetFloat(_saveName, _slider.value * _cameraSize);
    }
}
