using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    private Slider _slider;
    private string _saveName = "MusicVolume";

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        if (PlayerPrefs.HasKey(_saveName))
            _slider.value = PlayerPrefs.GetFloat(_saveName);
    }

    public void OnValueChanged()
    {
        PlayerPrefs.SetFloat(_saveName, _slider.value);
    }
}
