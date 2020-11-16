using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelRace : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private int _maxTime;

    private RocketMessage _rocketMessage;
    private LoadScene _restartScene;
    private float _elapsedTime = 0;
    private int _deadCount;
    private bool _isCounted;
    private int _seconds = 0;

    public int MaxTimeForLevel => _maxTime;
    public int RocketTimeLeft { get; private set; }

    private void Start()
    {
        _restartScene = GetComponent<LoadScene>();
        _rocketMessage = _rocket.GetComponent<RocketMessage>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _seconds)
        {
            _seconds++;
            RocketTimeLeft = _maxTime - _seconds;
            _timerText.text = RocketTimeLeft.ToString();
        }

        if (_rocket.IsDead && !_isCounted)
        {
            _deadCount++;
            _isCounted = true;

            if (_deadCount >= 5)
                _restartScene.LoadLevel();
        }
        else if (!_rocket.IsDead)
            _isCounted = false;

        if (_elapsedTime >= _maxTime)
        {
            _rocketMessage.ShowMessage("You louse :(", null);
            _timerText.gameObject.SetActive(false);
        }
        if (_elapsedTime >= _maxTime + 3.5f)
            _restartScene.LoadLevel();
    }
}
