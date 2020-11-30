using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonSize : MonoBehaviour
{
    [SerializeField] private RectTransform _buttonRectTransform;

    private Slider _slider;
    private float _scale = 0;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("UpButtonSize"))
        {
            _scale = PlayerPrefs.GetFloat("UpButtonSize");
            _slider.value = _scale;
            SetNewScale();
        }
        else
            PlayerPrefs.SetFloat("UpButtonSize", _slider.value);
    }

    private void SetNewScale()
    {
        _slider.value = _scale;
        _buttonRectTransform.localScale = new Vector3(_scale, _scale, _scale);
    }

    public void OnValueChanged()
    {
        PlayerPrefs.DeleteKey("UpButtonSize");
        PlayerPrefs.SetFloat("UpButtonSize", _slider.value);
        _scale = _slider.value;
        SetNewScale();
    }
}
