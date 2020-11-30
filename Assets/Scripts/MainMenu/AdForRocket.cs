using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdForRocket : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private int _rocketId;
    [SerializeField] private Button _startWatchingButton;
    [SerializeField] private ChooseRocketPanel _chooseRocketPanel;

    private string _myPlacementId = "rewardedVideo";
    private string _gameId = "3919219";
    private bool _testMode = false;

    private void Start ()
    {
        InitializeAd();
    }

    private void InitializeAd ()
    {
        if (!PlayerPrefs.HasKey($"Rocket{_rocketId}"))
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(_gameId, _testMode);

            _startWatchingButton.onClick.AddListener(() =>
            {
                Advertisement.Show(_myPlacementId);
                _startWatchingButton.gameObject.SetActive(false);
            });
        }
    }

    public void OnButtonClick ()
    {
    }

    public void OnUnityAdsDidError (string message)
    {
        Debug.Log("Error " + message);
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult)
    {
        if (placementId == _myPlacementId && showResult == ShowResult.Finished)
        {
            PlayerPrefs.SetInt($"Rocket{_rocketId}", _rocketId);
            PlayerPrefs.SetInt("CurrentRocket", _rocketId);
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void OnUnityAdsDidStart (string placementId)
    {
    }

    public void OnUnityAdsReady (string placementId)
    {
        if (!PlayerPrefs.HasKey($"Rocket{_rocketId}") && placementId == _myPlacementId && _startWatchingButton != null)
            _startWatchingButton.gameObject.SetActive(true);
    }
}
