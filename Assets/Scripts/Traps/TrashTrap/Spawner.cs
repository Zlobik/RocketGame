using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _trashPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private RocketMessage _rocketMessage;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private int _maxTime;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Transform _door;
    [SerializeField] private float _openningOffset;

    private float _elapsedTime = 0;
    private float _elapsedTime2 = 0;
    private float _timeLeft = 0;
    private Rocket _rocket;
    private int _tempTimer;
    private int _secondsCount = 0;

    private void Start()
    {
        _rocket = _rocketMessage.GetComponent<Rocket>();
        _tempTimer = _maxTime;
        _timerText.text = _maxTime.ToString();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        _elapsedTime2 += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            _timeLeft += _elapsedTime;
            _elapsedTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            Instantiate(_trashPrefab[Random.Range(0, _trashPrefab.Length)], _spawnPoints[spawnPointNumber]);
        }
        if (_elapsedTime2 >= 1)
        {
            _secondsCount++;
            _timerText.text = (_maxTime - _secondsCount).ToString();
            _elapsedTime2 = 0;
        }
        if (_timeLeft >= _maxTime)
        {
            _rocketMessage.ShowMessage("You win, go right", null);
            _door.DOMoveY(_door.position.y + _openningOffset, 3.5f);

            _timerText.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if (_rocket.IsDead)
        {
            _secondsCount = 0;
            _elapsedTime = 0;
            _timeLeft = 0;
            _maxTime = _tempTimer;
            _timerText.text = (_maxTime - _timeLeft).ToString();
        }
    }
}
