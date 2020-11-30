using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveChoosedRocket : MonoBehaviour
{
    [SerializeField] private int _rocketId;
    [SerializeField] private GameObject _nextRocketButton;

    private void Start ()
    {
        if (PlayerPrefs.HasKey($"Rocket{_rocketId}") && _rocketId < 3 && _nextRocketButton != null)
        {
            _nextRocketButton.SetActive(true);
        }
    }

    public void SaveRocket ()
    {
        if (PlayerPrefs.HasKey($"Rocket{_rocketId}"))
            PlayerPrefs.SetInt("CurrentRocket", _rocketId);
    }
}
