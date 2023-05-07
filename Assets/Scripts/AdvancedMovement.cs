using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    [SerializeField] private float _gravity = -9.81f;
        
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] float _fallingAcceleration = 0.5f;


    private Vector2 _moveDirection;
    private float _jumpForce;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // _jumpForce = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        _jumpForce = _jumpHeight;
    }

    private void FixedUpdate()
    {
        // Move(_moveDirection);
        MakeGravity();
            
        if (_groundChecker.IsGrounded && _moveDirection.y < 0)
        {
            _moveDirection.y = -2;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded)
        {
            Jump();
        }

        _moveDirection = new Vector2(Input.GetAxis("Horizontal") * _speed, _moveDirection.y);
        _rigidbody2D.velocity = _moveDirection;
    }

    // private void Move(Vector2 direction)
    // {
    //     _rigidbody2D.velocity = _speed * Time.deltaTime * direction;
    // }

    private void Jump()
    {
        _moveDirection.y = _jumpHeight;
        // _isInJump = true;
    }

    // private bool IsOnTheGround()
    // {
    //     return Physics.CheckSphere(_surfaceCheckerPivot.position, _checkSurfaceRadius, _surfaceMask);
    // }

    private void MakeGravity()
    {
        if (_groundChecker.IsGrounded == false)
        {
            _moveDirection.y += _gravity * _fallingAcceleration;
        }
    }
}