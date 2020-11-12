using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelStarts : MonoBehaviour
{
    [SerializeField] private Rocket _currentLevelRocket;
    [SerializeField] private Animator[] _rocketsAnimators;
    [SerializeField] private CapsuleCollider2D[] _rocketsCapsuleColliders;


    private void Start()
    {
        SetRocket();
    }

    private void SetRocket()
    {
        int _currentRocket = 0;

        if (PlayerPrefs.HasKey("ChoosedRocket"))
            _currentRocket = PlayerPrefs.GetInt("ChoosedRocket") - 1;
        else
            _currentRocket = 0;

        _currentLevelRocket.SetNewAnimator(_rocketsAnimators[_currentRocket]);
        _currentLevelRocket.SetNewCapsuleCollider(_rocketsCapsuleColliders[_currentRocket]);
    }
}
