using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRocket : MonoBehaviour
{
    [SerializeField] private Button[] _rockets;
    [SerializeField] private bool[] _isLocked;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (PlayerPrefs.HasKey("Rocket1"))
        {
            if (_isLocked[0])
                _isLocked[0] = false;
        }
        if (PlayerPrefs.HasKey("Rocket2"))
        {
            if (_isLocked[1])
                _isLocked[1] = false;
        }
        if (PlayerPrefs.HasKey("Rocket3"))
        {
            if (_isLocked[2])
                _isLocked[2] = false;
        }
    }
}
