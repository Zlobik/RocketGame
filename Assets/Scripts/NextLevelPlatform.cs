using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPlatform : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private LevelStars _levelStars;
    [SerializeField] private GameObject _nextLevelPanel;

    [SerializeField] private bool _isRace = false;
    [SerializeField] private LevelRace _levelRace;
    [SerializeField] private float _3starsTime;
    [SerializeField] private float _2starsTime;
    [SerializeField] private float _1starTime;

    private float _rocketTimeLeft = 0;

    private int _playerCollectStars;
    private int _starsOnLevel;
    private int _value;
    private bool _isDoTimeScale;
    private StarsPanel _starsPanel;

    private void Start()
    {
        _starsPanel = _nextLevelPanel.GetComponentInChildren<StarsPanel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rocket>(out Rocket rocket))
        {
            if (!_isRace)
            {
                _playerCollectStars = rocket.StarsCollected;
                _starsOnLevel = _levelStars.StarsOnLevel;
                CollectStars();
            }
            else if (_isRace)
            {
                _rocketTimeLeft = _levelRace.RocketTimeLeft;
                CollectStarsForRace();
            }

            _isDoTimeScale = true;

            SaveScene(_value);
            ShowNextLevelPanel();
        }
    }

    private void CollectStars()
    {
        if (_playerCollectStars > 0)
        {
            if (_playerCollectStars >= _starsOnLevel * 0.75f)
                _value = 3;
            else if (_playerCollectStars >= _starsOnLevel / 2)
                _value = 2;
            else if (_playerCollectStars >= 3)
                _value = 1;
        }
        else
            _value = 0;
    }

    private void CollectStarsForRace()
    {
        if (_rocketTimeLeft >= 0)
        {
            if (_rocketTimeLeft > _3starsTime)
                _value = 3;
            else if (_rocketTimeLeft > _2starsTime)
                _value = 2;
            else if (_rocketTimeLeft > _1starTime)
                _value = 1;
        }
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
                Time.timeScale = 0;
            else if (Time.timeScale == 0)
                _isDoTimeScale = false;
        }

        if (PlayerPrefs.GetInt(_sceneName) < value)
            PlayerPrefs.SetInt(_sceneName, value);

        _starsPanel.LoadStars(value);
    }
}
