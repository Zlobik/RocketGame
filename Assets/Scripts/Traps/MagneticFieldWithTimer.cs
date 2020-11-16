using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldWithTimer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _timeOn;
    [SerializeField] private float _timeOff;

    private AreaEffector2D _pointEffector;
    private float _elapsedTime = 0;
    private ParticleSystem _currentEffect;
    private bool _isOn = false;

    private void Start()
    {
        _pointEffector = GetComponent<AreaEffector2D>();
        _currentEffect = Instantiate(_effect, transform);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (!_isOn)
        {
            if (_elapsedTime >= _timeOff)
            {
                _elapsedTime = 0;
                _pointEffector.enabled = true;
                _currentEffect.gameObject.SetActive(true);
                _isOn = true;
            }
        }
        if (_isOn)
        {
            if (_elapsedTime >= _timeOn)
            {
                _elapsedTime = 0;
                _pointEffector.enabled = false;
                _currentEffect.gameObject.SetActive(false);
                _isOn = false;
            }
        }
    }
}
