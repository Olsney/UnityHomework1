using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsDestroyer : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _speed;
    [SerializeField] ContactFilter2D _filter;

    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private void FixedUpdate()
    {

        var collisionCount = _rigidbody2D.Cast(transform.right, _filter, _results, 10);

        if (collisionCount == 0)
        {
            _rigidbody2D.velocity = transform.right * _speed;
        }
    }
}