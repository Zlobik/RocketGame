using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HardCoreMode : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private UseSliderInsteadButtons _useSliderInsteadButtons;

    private void Start()
    {
        OnButtonClick();
    }

    public void OnButtonClick()
    {
        if (_text.text == "OFF")
        {
            _text.text = "ON";
            RunHardCoreMode();
        }
        else
        {
            _text.text = "OFF";
            StopHardCoreMode();
        }
    }

    private void RunHardCoreMode()
    {
        PlayerPrefs.SetInt("UseSliderInsteadButtons", 1);
        _effect.gameObject.SetActive(true);

        _useSliderInsteadButtons.MakeToggleActive(true);
        _useSliderInsteadButtons.OnBoolChanged();
    }

    private void StopHardCoreMode()
    {
        PlayerPrefs.SetInt("UseSliderInsteadButtons", 0);

        _useSliderInsteadButtons.MakeToggleActive(false);
        _useSliderInsteadButtons.OnBoolChanged();
    }
}
