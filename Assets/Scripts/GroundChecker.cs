using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _maxAllowedAngle = 45f;
    [SerializeField] private float _checkRadius = 0.4f;
    [SerializeField] private ContactFilter2D _filter;

    public bool IsGrounded { get; private set; }

    public Collider2D CurrentCollider
    {
        get { return _collisionsResult[0]; }
    }

    private List<Collider2D> _collisionsResult = new List<Collider2D>(1);
    private void Update()
    {
        IsGrounded = IsCollisionsExist();
    }

    private bool IsCollisionsExist() =>
        Physics2D.OverlapCircle(transform.position, _checkRadius, _filter, _collisionsResult) > 0;

    // public void OnCollisionEnter2D(Collision2D surface)
    // {
    //     float angle = Vector3.Angle(Vector3.up, surface.transform.up);
    //     Debug.Log($"Angle - {angle}, {surface.collider.name}");
    //
    //     if (angle < _maxAllowedAngle)
    //     {
    //         IsGrounded = true;
    //     }
    // }
    //
    // public void OnCollisionExit2D(Collision2D surface)
    // {
    //     IsGrounded = false;
    // }
}