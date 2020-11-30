using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private TMP_Text _tmpText;

    public void SetNewText()
    {
        _tmpText.text = _text;
    }
}
