using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveStrategy : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _speed;
    [SerializeField] Animator _animator;

    private const string Speed = "Speed";

    private void FixedUpdate()
    {
        _animator.SetInteger(Speed, 3);

        _rigidbody2D.velocity = transform.right * _speed;

        //float directionHorizontal = Input.GetAxis("Horizontal");
        //float directionVertical = Input.GetAxis("Vertical");

        //_rigidbody2D.velocity = transform.right * _speed * directionHorizontal;
        //_rigidbody2D.velocity = transform.up * _speed * directionVertical;
    }
}
