using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseRocket : MonoBehaviour
{
    [SerializeField] private Button[] _rockets;
    [SerializeField] private bool[] _isLocked;
    [SerializeField] private TMP_Text[] _lockedText;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Rocket1"))
            PlayerPrefs.SetInt("Rocket1", 1);

        Initialize();
    }

    private void Initialize()
    {
        if (PlayerPrefs.HasKey("Rocket1"))
        {
            if (_isLocked[0])
                _isLocked[0] = false;
        }
        else
            _rockets[0].GetComponent<CanvasGroup>().alpha = 0.5f;

        if (PlayerPrefs.HasKey("Rocket2"))
        {
            if (_isLocked[1])
            {
                _isLocked[1] = false;
                _lockedText[1].gameObject.SetActive(false);
                _rockets[1].GetComponent<TMP_Text>().text = "CHOOSE ROCKET";
                _rockets[1].GetComponent<CanvasGroup>().alpha = 1f;
            }
        }
        else
            _rockets[1].GetComponent<CanvasGroup>().alpha = 0.5f;

        if (PlayerPrefs.HasKey("Rocket3"))
        {
            if (_isLocked[2])
            {
                _isLocked[2] = false;
                _lockedText[2].gameObject.SetActive(false);
                _rockets[2].GetComponent<TMP_Text>().text = "CHOOSE ROCKET";
                _rockets[1].GetComponent<CanvasGroup>().alpha = 1f;
            }
        }
        else
            _rockets[2].GetComponent<CanvasGroup>().alpha = 0.5f;
    }

    public void OnButtonClick(int rocket)
    {
        if (!_isLocked[rocket - 1] && rocket > 1 && rocket <= 3)
            PlayerPrefs.SetInt("CurrentRocket", rocket);
        else
        {
            Initialize();
            Debug.Log("This rocket is locked");
        }
    }
}
