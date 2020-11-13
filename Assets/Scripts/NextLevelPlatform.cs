using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPlatform : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private LevelStars _levelStars;
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private StarsPanel _starsPanel;

    private int _playerCollectStars;
    private int _starsOnLevel;
    private int _value;
    private bool _isDoTimeScale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rocket>(out Rocket rocket))
        {
            _playerCollectStars = rocket.StarsCollected;
            _starsOnLevel = _levelStars.StarsOnLevel;

            _isDoTimeScale = true;

            CollectStars();
            SaveScene(_value);
            ShowNextLevelPanel();
        }
    }

    private void CollectStars()
    {
        if (_playerCollectStars >= _starsOnLevel * 0.75f)
            _value = 3;
        else if (_playerCollectStars >= _starsOnLevel / 2)
            _value = 2;
        else if (_playerCollectStars >= 3)
            _value = 1;
        else
            _value = 0;
    }

    private void ShowNextLevelPanel()
    {
        _nextLevelPanel.SetActive(true);
        SpriteRenderer _panelRenderer = _nextLevelPanel.GetComponent<SpriteRenderer>();
        _nextLevelPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        _panelRenderer.DOFade(1, 0.5f);
    }

    private void SaveScene(int value)
    {
        if (_isDoTimeScale)
        {
            if (Time.timeScale != 0)
                Time.timeScale = 0.3f;
            else if (Time.timeScale == 0.3f)
                _isDoTimeScale = false;
        }

        if (PlayerPrefs.GetInt(_sceneName) < value)
            PlayerPrefs.SetInt(_sceneName, value);

        _starsPanel.LoadStars(value);
    }
}
