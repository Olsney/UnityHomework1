using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IEggCollector
{
    //[SerializeField] private UnityEvent _hit;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.TryGetComponent(out Egg egg))
    //    {
    //        _hit?.Invoke();
    //    }
    //}
}

public interface IEggCollector
{

}
