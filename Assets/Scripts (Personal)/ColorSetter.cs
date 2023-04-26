using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;

    private SpriteRenderer _target;
    private float _runningTime;
    private Color _currentColor;

    private void Start()
    {
        _target = GetComponent<SpriteRenderer>();
        _currentColor = _target.color;
    }

    public void Update()
    {
        if (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizedRunningTime = _runningTime / _duration;

            //Color newColor = new Color(_targetColor.r * normalizedRunningTime, _targetColor.g * normalizedRunningTime, _targetColor.b * normalizedRunningTime);

            //_target.color = newColor;

            _target.color = Color.Lerp(_currentColor, _targetColor, normalizedRunningTime);
        }

    }
}