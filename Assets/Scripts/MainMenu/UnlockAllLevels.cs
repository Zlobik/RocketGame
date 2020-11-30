using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockAllLevels : MonoBehaviour
{
    private int _levelsCount = 5;

    public void UnlockLevels()
    {
        for (int i = 1; i < _levelsCount; i++)
            PlayerPrefs.SetString($"Level0{i}", $"Level0{i}");

        SceneManager.LoadScene("MainMenu");
    }
}
