using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisableLearningToogle : MonoBehaviour
{
    [SerializeField] private GameObject _learningPanel;

    private Toggle _toggle;
    private string _saveName = "LearningToggle";

    private void Start()
    {
        _toggle = GetComponent<Toggle>();

        if (PlayerPrefs.HasKey(_saveName) && PlayerPrefs.GetInt(_saveName) == 1)
            _toggle.isOn = false;
        else if (PlayerPrefs.GetInt(_saveName) == 0)
            _toggle.isOn = true;
    }

    public void SaveBool()
    {
        int value;

        if (_toggle.isOn)
            value = 0;
        else
            value = 1;

        PlayerPrefs.SetInt(_saveName, value);
    }
}
