using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class WatchVideoForRocket : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameObject _startWatchingButton;
    [SerializeField] private int _rocketId;

    private string _gameId = "3900251";
    private string _myPlacementId = "rewardedVideo";
    private bool _testMode = true;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);

        _startWatchingButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Advertisement.Show(_myPlacementId);
            _startWatchingButton.SetActive(false);
        });
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) 
    { 
        if(showResult == ShowResult.Finished)
        {
            _startWatchingButton.TryGetComponent<SaveChoosedRocket>(out SaveChoosedRocket saveChoosedRocket);

            saveChoosedRocket.SaveRocket();
        }
        else if(showResult == ShowResult.Skipped)
        {

        }
        else if(showResult == ShowResult.Failed)
        {

        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if(placementId == _myPlacementId)
            _startWatchingButton.SetActive(true);
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }
}
