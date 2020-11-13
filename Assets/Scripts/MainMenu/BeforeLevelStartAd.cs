using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BeforeLevelStartAd : MonoBehaviour
{
    private string _gameId = "3900251";
    private bool _testMode = false;

    private void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        var waitForSeconds = new WaitForSeconds(0.5f);

        while (!Advertisement.IsReady("MainBeforeLevelStart"))
            yield return waitForSeconds;

        Advertisement.Banner.SetPosition(BannerPosition.CENTER);
        Advertisement.Show("MainBeforeLevelStart");
    }
}
