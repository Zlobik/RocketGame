using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] _background;

    private void Start()
    {
        int value = Random.Range(0, _background.Length);

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = _background[value];
    }
}
