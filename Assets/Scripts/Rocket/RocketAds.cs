using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RocketAds : MonoBehaviour
{
    private Rocket _rocket;

    private string _gameId = "3900251";
    private bool _testMode = false;

    private int _deathCount = 0;
    private bool _isCounted;

    private void Start()
    {
        _rocket = GetComponent<Rocket>();
    }

    IEnumerator ShowAdVideo()
    {
        _deathCount = 0;

        var waitForSeconds = new WaitForSeconds(0.5f);

        while (!Advertisement.IsReady("MainBeforeLevelStart"))
            yield return waitForSeconds;

        Advertisement.Banner.SetPosition(BannerPosition.CENTER);
        Advertisement.Show("MainBeforeLevelStart");
    }

    private void Update()
    {
        if (_rocket.IsDead)
        {
            if (!_isCounted)
            {
                _deathCount++; ;
                _isCounted = true;
            }
        }
        if (_deathCount >= 4)
            StartCoroutine(ShowAdVideo());
        else if (!_rocket.IsDead && _isCounted)
            _isCounted = false;
    }
}
