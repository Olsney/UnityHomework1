using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent((typeof(SpriteRenderer)))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private SpriteRenderer _spriteRenderer;
    private float _movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _isGrounded = _groundChecker.IsGrounded;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            Jump();

        _movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        bool isWalkingBack = _movement < 0;

        Move(new Vector3(_movement, 0, 0));
        _spriteRenderer.flipX = isWalkingBack;
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}