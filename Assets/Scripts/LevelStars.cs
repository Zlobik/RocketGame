using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStars : MonoBehaviour
{
    public int StarsOnLevel { get; private set; }

    private void Start()
    {
        StarsOnLevel = transform.childCount;
    }
}
