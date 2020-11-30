using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemoveAllSaves : MonoBehaviour
{
    public void OnButtonClick()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
