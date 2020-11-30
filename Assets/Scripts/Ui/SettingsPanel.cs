using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private bool _timer = false;
    private float _elapsedTime = 0;


    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _timer = true;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_timer && _elapsedTime > 0.25f)
        {
            _elapsedTime = 0;
            _canvasGroup.alpha = 1;
            gameObject.SetActive(false);
        }
    }
}
