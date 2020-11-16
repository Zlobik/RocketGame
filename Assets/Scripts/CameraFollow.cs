using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet = new Vector3(0, 0, -10);

    private Camera _camera;
    private Rocket _rocket;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        _camera.orthographicSize = PlayerPrefs.GetFloat("FieldOfView");

        transform.position = _target.position + _offSet;
        _rocket = _target.GetComponent<Rocket>();
    }

    private void Update()
    {
        if (!_rocket.IsDead)
            transform.position = Vector3.Lerp(transform.position, _target.position + _offSet, 1500 * Time.deltaTime);

        if (_camera.orthographicSize != PlayerPrefs.GetFloat("FieldOfView"))
            _camera.orthographicSize = PlayerPrefs.GetFloat("FieldOfView");
    }
}
