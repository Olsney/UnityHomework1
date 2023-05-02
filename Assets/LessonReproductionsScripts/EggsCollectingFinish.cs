using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsCollectingFinish : MonoBehaviour
{
    private InEggPoint[] _eggs;

    //11) Роман меняет почему-то присваивание _eggs (у него в лекции - _points) из методе Awake в метод OnEnable. Почему? Вначале ведь написал в Awake.
    //Потом просто сказал "Мы сейчас немного изменимся", стёр и поменял на onEnable.

    //public void Awake()
    //{
    //    _eggs = gameObject.GetComponentsInChildren<InEggPoint>();
    //}

    private void OnEnable()
    {
        _eggs = gameObject.GetComponentsInChildren<InEggPoint>();

        foreach (var egg in _eggs)
        {
            egg.Reached += OnInEggPointReached; 
            //13) Тут мы подписываем на си шарп событие вызов метода OnInEggPointReached,
            //чтобы когда мы писали Reached.Invoke() - вызывался метод OnInEggPointReached?
            //14) Мы ведь нигде в коде не инвоукаем сишарп событие Reached, т.е. у него нет использований. Зачем он тогда нужен и как используется, не вызываясь?
        }
    }

    private void OnDisable()
    {
        foreach (var egg in _eggs)
        {
            egg.Reached -= OnInEggPointReached;
        }
    }

    private void OnInEggPointReached()
    {
        foreach (var egg in _eggs)
        {
            if(egg.IsReached == false)
            {
                return;
            }
        }

        Debug.LogError("All eggs have been collected!");
    }
}
