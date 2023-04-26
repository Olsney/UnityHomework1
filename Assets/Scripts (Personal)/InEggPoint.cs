using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;

public class InEggPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();

    public bool IsReached { get; private set; }

    //1) Почему строчкой выше мы использовали UnityEvent как событие, а тут далше про UnityAction Рома говорит, что мы просто имитируем такое же поле _reached и
    //говорит, что это точно такое же событие? Мы ведь почему-то используем именно юнити экшн, а не ивент.
    //2) Что за UnityAction, в чем тогда разница с UnityEvent и почему мы используем его?
    //3) Зачем мы в принципе используем сишарп событие, почему не юнити событие? В чём разница тогда?
    //4) Почему мы в сишарп событие оборачиваем юнитиэкшн? Зачем?
    //5) Не понял про то, что даёт нам именно такое предоставление доступа к полю _reached и чем плохо давать его наружу, ведь Рома сам говорит, что
    //мы точно так же можно сказать отдаём его наружу для использования, просто через сишарп юнити событие(ещё и почему-то экшн, а не ивент).
    //6) Пересмотриваю и никак не могу уловить логику и алгоритм использования в лекции юнитиивента/экшна и сишарп ивента, которая объясняется в лекции.
    //Можете плиз объяснить? Именно что, как, куда и где мы меняем и задаём, и как именно мы это используем, взаимная логика классов InEggPoint и EggsCollectingFinish.

    public event UnityAction Reached
    {
        add => _reached.AddListener(value); //7) Правильно я понимаю, что тут мы подписали на сишарп событие игрока, который вошёл в триггер? 
        //value - игрок из метода TryGetComponent?
        remove => _reached.RemoveListener(value); //Тут, соответственно, отписали?
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player eggCollector)) 
        {
            Debug.Log(eggCollector.gameObject.name);

            if (IsReached)
            {
                return;
            }

            IsReached = true;

            //8) Зачем нам здесь именно out? Мы ведь его используем когда нам надо проинициализировать что-то внутри.
            //Но мы в TryGetComponent<Player> итак получим игрока, если зайдёт игрок. Других метод не воспримет. 
            //и если мы его изменим внутри метода, то т.к. мы работаем со ссылочным типом, он поменяется и на выходе без всяких out. 
            //И ситуации, когда мы внутри триггера создадим игрока и вернём его наружу тоже нет. В чём тогда смысл аута здесь, зачем он?
            _reached.Invoke();
            //9) Где прописан метод, который мы инвоукаем? Мы ведь в коде его нигде не прописали. 
            //10) Если я хочу в коде прописать метод, который будет вызывать ивент, где и как это правильно делать?
        }
    }
}
