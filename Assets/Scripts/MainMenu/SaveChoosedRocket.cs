using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChoosedRocket : MonoBehaviour
{
    [SerializeField] private int _number;

    public int Number => _number;

    public void SaveRocket()
    {
        PlayerPrefs.SetInt("ChoosedRocket", _number);

        PlayerPrefs.SetInt($"Rocket{_number}", _number);

        Debug.Log("Rocket choosed");
    }
}
