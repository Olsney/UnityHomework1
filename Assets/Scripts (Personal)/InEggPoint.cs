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

    //1) ������ �������� ���� �� ������������ UnityEvent ��� �������, � ��� ����� ��� UnityAction ���� �������, ��� �� ������ ��������� ����� �� ���� _reached �
    //�������, ��� ��� ����� ����� �� �������? �� ���� ������-�� ���������� ������ ����� ����, � �� �����.
    //2) ��� �� UnityAction, � ��� ����� ������� � UnityEvent � ������ �� ���������� ���?
    //3) ����� �� � �������� ���������� ������ �������, ������ �� ����� �������? � ��� ������� �����?
    //4) ������ �� � ������ ������� ����������� ���������? �����?
    //5) �� ����� ��� ��, ��� ��� ��� ������ ����� �������������� ������� � ���� _reached � ��� ����� ������ ��� ������, ���� ���� ��� �������, ���
    //�� ����� ��� �� ����� ������� ����� ��� ������ ��� �������������, ������ ����� ������ ����� �������(��� � ������-�� ����, � �� �����).
    //6) ������������� � ����� �� ���� ������� ������ � �������� ������������� � ������ �����������/����� � ������ ������, ������� ����������� � ������.
    //������ ���� ���������? ������ ���, ���, ���� � ��� �� ������ � �����, � ��� ������ �� ��� ����������, �������� ������ ������� InEggPoint � EggsCollectingFinish.

    public event UnityAction Reached
    {
        add => _reached.AddListener(value); //7) ��������� � �������, ��� ��� �� ��������� �� ������ ������� ������, ������� ����� � �������? 
        //value - ����� �� ������ TryGetComponent?
        remove => _reached.RemoveListener(value); //���, ��������������, ��������?
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

            //8) ����� ��� ����� ������ out? �� ���� ��� ���������� ����� ��� ���� ������������������� ���-�� ������.
            //�� �� � TryGetComponent<Player> ���� ������� ������, ���� ����� �����. ������ ����� �� ���������. 
            //� ���� �� ��� ������� ������ ������, �� �.�. �� �������� �� ��������� �����, �� ���������� � �� ������ ��� ������ out. 
            //� ��������, ����� �� ������ �������� �������� ������ � ����� ��� ������ ���� ���. � ��� ����� ����� ���� �����, ����� ��?
            _reached.Invoke();
            //9) ��� �������� �����, ������� �� ���������? �� ���� � ���� ��� ����� �� ���������. 
            //10) ���� � ���� � ���� ��������� �����, ������� ����� �������� �����, ��� � ��� ��� ��������� ������?
        }
    }
}
