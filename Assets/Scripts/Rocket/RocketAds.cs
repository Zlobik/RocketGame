using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RocketAds : MonoBehaviour
{
    private Rocket _rocket;

    private string _gameId = "3919219";
    private bool _testMode = false;
    private int _numberOfDeathBeforeAdServing = 4;

    private int _deathCount = 0;
    private bool _isCounted;
    private int _showedAdCounter = 0;

    private void Start()
    {
        _rocket = GetComponent<Rocket>();
        Advertisement.Initialize(_gameId, _testMode);
    }

    IEnumerator ShowAdVideo()
    {
        _deathCount = 0;

        var waitForSeconds = new WaitForSeconds(0.5f);

        while (!Advertisement.IsReady("MainBeforeLevelStart"))
            yield return waitForSeconds;

        Advertisement.Show("MainBeforeLevelStart");
    }

    private void Update()
    {
        if (_rocket.IsDead)
        {
            if (!_isCounted)
            {
                _deathCount++;
                _isCounted = true;
            }
        }
        if (_deathCount >= _numberOfDeathBeforeAdServing)
        {
            StartCoroutine(ShowAdVideo());
            _showedAdCounter++;

            if (_showedAdCounter == 4)
            {
                _numberOfDeathBeforeAdServing++;
                _showedAdCounter = 0;
            }
        }
        else if (!_rocket.IsDead && _isCounted)
            _isCounted = false;
    }
}
