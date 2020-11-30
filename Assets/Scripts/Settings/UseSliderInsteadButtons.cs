using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSliderInsteadButtons : MonoBehaviour
{
    [SerializeField] private RocketMover _rocketMover;
    [SerializeField] private GameObject _rotateSlider;
    [SerializeField] private GameObject[] _rotateButtons;
    [SerializeField] private Toggle _toggle;

    private string _saveName = "UseSliderInsteadButtons";

    private void Start()
    {
        if (PlayerPrefs.GetInt(_saveName) == 1)
            _toggle.isOn = true;
        else
            _toggle.isOn = false;

        OnBoolChanged();
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(_saveName) == 1)
            _toggle.isOn = true;
        else
            _toggle.isOn = false;

        OnBoolChanged();
    }

    public void MakeToggleActive(bool isTrue)
    {
        _toggle.isOn = isTrue;
    }

    public void OnBoolChanged()
    {
        int value = 0;

        if (_toggle.isOn)
            value = 1;
        else if (!_toggle.isOn)
            value = 0;

        PlayerPrefs.SetInt(_saveName, value);

        if (PlayerPrefs.HasKey(_saveName) && PlayerPrefs.GetInt(_saveName) == 1)
        {
            _toggle.isOn = true;
            _rocketMover.UsingRotationSlider(true);

            _rotateButtons[0].SetActive(false);
            _rotateButtons[1].SetActive(false);
            _rotateSlider.SetActive(true);
        }
        else if (PlayerPrefs.GetInt(_saveName) == 0)
        {
            _toggle.isOn = false;
            _rocketMover.UsingRotationSlider(false);

            _rotateButtons[0].SetActive(true);
            _rotateButtons[1].SetActive(true);
            _rotateSlider.SetActive(false);
        }
    }
}
