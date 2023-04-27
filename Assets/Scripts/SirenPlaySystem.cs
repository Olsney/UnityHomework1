using UnityEngine;

public class SirenPlaySystem : MonoBehaviour
{
    [SerializeField] private InHomePoint _inHomePoint;

    [SerializeField] private SignalizationWithSpeed _signalizationWithSpeed;

    public void OnEnable()
    {
        _inHomePoint.HouseEntered += _signalizationWithSpeed.IncreaseVolume;
        _inHomePoint.HouseAbonded += _signalizationWithSpeed.DecreaseVolume;
    }

    public void OnDisable()
    {
        _inHomePoint.HouseEntered -= _signalizationWithSpeed.IncreaseVolume;
        _inHomePoint.HouseAbonded -= _signalizationWithSpeed.DecreaseVolume;
    }
}