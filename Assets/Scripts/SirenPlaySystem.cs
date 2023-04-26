using UnityEngine;

public class SirenPlaySystem : MonoBehaviour
{
    // !!!Перенести в сигнализацию!
    [SerializeField] private InHousePoint _inHousePoint;
    // [SerializeField] private Signalization _signalization;
    [SerializeField] private SignalizationWithSpeed _signalizationWithSpeed;

    public void OnEnable()
    {
        //Вариант с изменением звука в течении определённого времени
        // _inHousePoint.HouseEntered += _signalization.StartSignalSound;
        // _inHousePoint.HouseAbonded += _signalization.StopSignalSound;
        
        //Вариант с изменением звука в зависимости от скорости
        _inHousePoint.HouseEntered += _signalizationWithSpeed.IncreaseVolume;
        _inHousePoint.HouseAbonded += _signalizationWithSpeed.DecreaseVolume;
    }

    public void OnDisable()
    {
        //Вариант с изменением звука в течении определённого времени
        // _inHousePoint.HouseAbonded -= _signalization.StartSignalSound;
        // _inHousePoint.HouseEntered -= _signalization.StopSignalSound;
        
        //Вариант с изменением звука в зависимости от скорости

        _inHousePoint.HouseEntered -= _signalizationWithSpeed.IncreaseVolume;
        _inHousePoint.HouseAbonded -= _signalizationWithSpeed.DecreaseVolume;
    }
}
