using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelStartInitialize : MonoBehaviour
{
    [SerializeField] private GameObject[] _rocketPrefabs;

    private Animator _animator;
    private CapsuleCollider2D _capsuleCollider;

    private void Start()
    {
        int currentRocket;

        if (PlayerPrefs.HasKey("CurrentRocket"))
            currentRocket = PlayerPrefs.GetInt("CurrentRocket");
        else
            currentRocket = 1;

        _animator = _rocketPrefabs[currentRocket - 1].GetComponent<Animator>();
        _capsuleCollider = _rocketPrefabs[currentRocket - 1].GetComponent<CapsuleCollider2D>();

        CapsuleCollider2D currentCapsuleCollider = GetComponent<CapsuleCollider2D>();

        GetComponent<Animator>().runtimeAnimatorController = _animator.runtimeAnimatorController;

        currentCapsuleCollider.offset = _capsuleCollider.offset;
        currentCapsuleCollider.size = _capsuleCollider.size;
    }
}
