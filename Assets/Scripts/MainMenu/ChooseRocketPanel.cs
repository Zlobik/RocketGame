using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRocketPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _rockets;
    [SerializeField] private Button[] _watchAdForRocketButtons;
    [SerializeField] private Button[] _chooseRocketButtons;
    [SerializeField] private Animator[] _rocketsAnimators;

    private string _currentRocket = "CurrentRocket";

    private void Start ()
    {
        if (!PlayerPrefs.HasKey(_currentRocket))
            PlayerPrefs.SetInt(_currentRocket, 1);
        if (!PlayerPrefs.HasKey("Rocket1"))
            PlayerPrefs.SetInt("Rocket1", 1);

        Refresh();
    }

    private void OnEnable ()
    {
        Refresh();
        RefreshAnimation();
    }

    public void RefreshAnimation ()
    {
        int currentRocket = 0;

        if (PlayerPrefs.HasKey(_currentRocket))
            currentRocket = PlayerPrefs.GetInt(_currentRocket) - 1;

        _rocketsAnimators[currentRocket].SetBool("IsPressedUpButton", true);

        for (int i = 0; i < _rocketsAnimators.Length; i++)
        {
            if (i != currentRocket)
                _rocketsAnimators[i].SetBool("IsPressedUpButton", false);
        }
    }

    public void Refresh ()
    {
        for (int i = 0; i < _rockets.Length; i++)
        {
            if (PlayerPrefs.HasKey($"Rocket{i + 1}"))
                _chooseRocketButtons[i].interactable = true;
            else
            {
                _chooseRocketButtons[i].interactable = false;
                _watchAdForRocketButtons[i].gameObject.SetActive(true);
            }
        }
    }
}
