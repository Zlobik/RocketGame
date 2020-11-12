using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorBool : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetBool(bool isTrue)
    {
        _animator.SetBool("IsPressedUpButton" , isTrue);
    }
}
