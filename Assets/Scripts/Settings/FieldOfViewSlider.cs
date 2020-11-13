using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldOfViewSlider : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _cameraSize;

    private Slider _slider;
    private string _saveName;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _saveName = "FieldOfView";

        if (!PlayerPrefs.HasKey(_saveName))
            PlayerPrefs.SetFloat(_saveName, 1f);

        _camera.orthographicSize = PlayerPrefs.GetFloat(_saveName) * _cameraSize;
        _slider.value = PlayerPrefs.GetFloat(_saveName);
    }

    public void OnValueChanged()
    {
        if (_slider.value >= 0.4f)
        {
            PlayerPrefs.SetFloat(_saveName, _slider.value);
            _camera.orthographicSize = _slider.value * _cameraSize;
        }
    }
}
