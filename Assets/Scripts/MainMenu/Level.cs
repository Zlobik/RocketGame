using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform[] _stars;
    [SerializeField] private string _sceneName;
    [SerializeField] private string _previousSceneName;

    private CanvasGroup _canvasGroup;
    private Button _button;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _button = GetComponent<Button>();

        if (_sceneName == "Level01" && !PlayerPrefs.HasKey("Level01"))
            PlayerPrefs.SetInt("Level01", 0);

        if (PlayerPrefs.HasKey(_sceneName) || PlayerPrefs.HasKey(_previousSceneName))
            MakeEnable();
        else
            MakeDisable();
    }

    private void MakeEnable()
    {
        if (PlayerPrefs.HasKey(_sceneName))
        {
            for (int i = 0; i < PlayerPrefs.GetInt(_sceneName); i++)
                _stars[i].gameObject.SetActive(true);
        }

        _canvasGroup.interactable = true;
        _canvasGroup.alpha = 1f;
        _button.interactable = true;
    }

    private void MakeDisable()
    {
        _button.interactable = false;
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.interactable = false;
    }
}
