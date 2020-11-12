using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChoosedRocket : MonoBehaviour
{
    [SerializeField] private int _number;

    public void SaveRocket(string rocketName)
    {
        PlayerPrefs.SetInt("ChoosedRocket", _number);
    }
}
