using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _emptyStars;

    public void LoadStars(int _starsForLevel)
    {
        if (_starsForLevel <= 3 && _starsForLevel > 0)
            for (int i = 0; i < _starsForLevel; i++)
                _emptyStars[i].SetActive(true);
    }
}
