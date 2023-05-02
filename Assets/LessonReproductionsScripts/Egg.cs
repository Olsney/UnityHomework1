using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Egg : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }

    public void Awake()
    {
        Debug.Log("hi!");
    }

    public void Update()
    {
        
    }
}
