using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet = new Vector3(0, 0, -10);

    private AudioSource _audioSource;
    private Camera _camera;
    private Rocket _rocket;
    private Vector3 _currentCheckpoint;
    private bool _isSetNewCheckpoint = false;

    private float _elapsedTime = 0;

    private void Awake ()
    {
        _camera = GetComponent<Camera>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");

        if (PlayerPrefs.HasKey("FieldOfView"))
            _camera.orthographicSize = PlayerPrefs.GetFloat("FieldOfView");
        else
        {
            PlayerPrefs.SetFloat("FieldOfView", 5);
            _camera.orthographicSize = 5 ;
        }

        transform.position = _target.position + _offSet;
        _rocket = _target.GetComponent<Rocket>();

        _currentCheckpoint = _rocket.CurrentCheckPoint;
    }

    private void LateUpdate ()
    {
        if (!_rocket.IsDead)
        {
            if (!_isSetNewCheckpoint)
                _isSetNewCheckpoint = true;
            transform.position = Vector3.Lerp(transform.position, _target.position + _offSet, 1500 * Time.deltaTime);
        }

        if (_camera.orthographicSize != PlayerPrefs.GetFloat("FieldOfView"))
            _camera.orthographicSize = PlayerPrefs.GetFloat("FieldOfView");

        if (PlayerPrefs.HasKey("MusicVolume") && _audioSource.volume != PlayerPrefs.GetFloat("MusicVolume"))
            _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");

        if (_rocket.IsDead)
        {
            if (transform.position != _currentCheckpoint && _isSetNewCheckpoint)
            {
                _elapsedTime += Time.deltaTime;

                if (_elapsedTime >= 0.5f)
                {
                    transform.DOMove(_currentCheckpoint, 1.25f);
                    _isSetNewCheckpoint = false;
                    _elapsedTime = 0;
                }
            }
        }
    }

    public void SetNewCheckPoint (Vector3 checkpointPosition)
    {
        _currentCheckpoint = checkpointPosition;
    }
}
