using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    private string _gameId = "3900251";
    private bool _testMode = true;

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

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("MainBeforeLevelStart");
    }
}
