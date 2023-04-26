using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;
    [SerializeField] private float _duration = 5;

    private Coroutine _volumeFadeJob;
    
    public void StartSignalSound()
    {
        StopVolumeFadeJob();

        _volumeFadeJob = StartCoroutine(MakeSignal(_duration));
    }

    public void StopSignalSound()
    {
        StopVolumeFadeJob();
        _volumeFadeJob = StartCoroutine(TakeAwaySignal(_duration));
    }

    private IEnumerator TakeAwaySignal(float duration)
    {
        float timeFollower = 0;

        while (timeFollower < duration)
        {
            float volume = _signalization.volume;
            float completeChangingVolumeTime = Time.deltaTime;

            volume = Mathf.MoveTowards(volume, 0, completeChangingVolumeTime / duration);

            _signalization.volume = volume;

            yield return null;

            timeFollower += completeChangingVolumeTime;
        }
    }

    private void StopVolumeFadeJob()
    {
        if (_volumeFadeJob != null)
        {
            StopCoroutine(_volumeFadeJob);
        }
    }

    private IEnumerator MakeSignal(float duration)
    {
        float timeFollower = 0;
        _signalization.volume = 0;
        _signalization.Play();

        while (timeFollower < duration)
        {
            float volume = _signalization.volume;
            float completeChangingVolumeTime = Time.deltaTime;

            volume = Mathf.MoveTowards(volume, 1, completeChangingVolumeTime / duration);

            _signalization.volume = volume;

            yield return null;

            timeFollower += completeChangingVolumeTime;
        }
    }
    
    //1. Переделать на вариант с одним методом, где будет speed и мы будем в этом методе задавать конечную точку и, соответственно, скорость смены звука от громкого к тихому.
    //2. Со старым вариантом вынести из двух методов дубляж кода в один отдельный метод(там, где он есть).
}