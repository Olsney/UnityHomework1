using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent((typeof(SpriteRenderer)))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded => Mathf.Abs(_rigidbody.velocity.y) < 0.05f;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            Jump();
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        bool isWalkingBack = movement < 0;

        transform.position += _speed * Time.deltaTime * new Vector3(movement, 0, 0);

        _spriteRenderer.flipX = isWalkingBack;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }
}