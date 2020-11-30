using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningPanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private float _elapsedTime = 0;

    private void Start()
    {
        CheckLearningToggle();

        _canvasGroup = GetComponent<CanvasGroup>();

        _canvasGroup.alpha = 1;
    }

    private void CheckLearningToggle()
    {
        if (PlayerPrefs.HasKey("LearningToggle"))
        {
            if (PlayerPrefs.GetInt("LearningToggle") == 0)
                gameObject.SetActive(false);
        }
        else
            PlayerPrefs.SetInt("LearningToggle", 1);
    }

    private void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime;

        if (_elapsedTime >= 10) 
        {
            _elapsedTime = 0;

            CheckLearningToggle();
        }
    }
}
