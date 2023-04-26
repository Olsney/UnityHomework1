using System.Collections;
using UnityEngine;

public class SignalizationWithSpeed : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;
    [SerializeField] private float _speed;

    private Coroutine _volumeChangeJob;
    private float _targetVolume;

    public void Start()
    {
        _signalization.volume = 0;
    }

    public void IncreaseVolume()
    {
        _targetVolume = 1;
        _signalization.Play();

        StopVolumeChanging();
        _volumeChangeJob = StartCoroutine(ChangeVolume(_targetVolume));
    }

    public void DecreaseVolume()
    {
        _targetVolume = 0;

        StopVolumeChanging();
        _volumeChangeJob = StartCoroutine(ChangeVolume(_targetVolume));
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_signalization.volume != target)
        {
            _signalization.volume = Mathf.MoveTowards(_signalization.volume, target, _speed * Time.deltaTime);
            
            yield return null;
        }
    }

    private void StopVolumeChanging()
    {
        if (_volumeChangeJob != null)
        {
            StopCoroutine(_volumeChangeJob);
        }
    }
}