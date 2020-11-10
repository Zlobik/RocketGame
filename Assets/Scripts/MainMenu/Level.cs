using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform[] _stars;
    [SerializeField] private string _sceneName;
    [SerializeField] private bool _isFirstLevel;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        if (_sceneName == "Level01" && !PlayerPrefs.HasKey("Level01"))
            PlayerPrefs.SetInt("Level01", 0);

        if (PlayerPrefs.HasKey(_sceneName))
            MakeEnable();
        else
            MakeDisable();
    }

    private void MakeEnable()
    {
        for (int i = 0; i < PlayerPrefs.GetInt(_sceneName); i++)
            _stars[i].gameObject.SetActive(true);

        _canvasGroup.interactable = true;
        _canvasGroup.alpha = 1f;
    }

    private void MakeDisable()
    {
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.interactable = false;
    }
}
