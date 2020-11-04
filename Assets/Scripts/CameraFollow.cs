using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet;


    private void Start()
    {
        _offSet = transform.position - _target.position;
    }

    public void ChangeCameraPosition(Vector3 position)
    {
        transform.position = position + _offSet;
    }

    private void Update()
    {
        //if (transform.position != _target.position + _offSet)
        //    transform.DOMove(_target.position + _offSet, Time.fixedDeltaTime);

        //transform.position = _target.position + _offSet;

    }
}
