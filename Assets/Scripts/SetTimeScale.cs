using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimeScale : MonoBehaviour
{
    public void SetNewTimeScale(float value)
    {
        Time.timeScale = value;
    }
}
