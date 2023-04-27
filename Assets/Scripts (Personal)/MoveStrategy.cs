using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveStrategy : MonoBehaviour
{
    public float GravityInflyModifier = 1;
    public float MinGroundNormalY = .65f;
    public Vector2 GlobalVelocity;
    public LayerMask LayerMask;

    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _speed;
    [SerializeField] Animator _animator;
    
    protected Vector2 TargetVelocity;
    protected bool IsGrounded;
    protected Vector2 GroundNormal;
    protected ContactFilter2D ContactFilter;
    protected RaycastHit2D[] HitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> HitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;
    

    private const string Speed = "Speed";

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ContactFilter.useTriggers = false;
        ContactFilter.SetLayerMask(LayerMask);
        ContactFilter.useLayerMask = true;
    }
    
    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");

        TargetVelocity = new Vector2(horizontalDirection, 0);

        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            GlobalVelocity.y = 5;
        }
    }
    
    private void FixedUpdate()
    {
        _animator.SetInteger(Speed, 3);
        
        GlobalVelocity += GravityInflyModifier * Time.deltaTime * Physics2D.gravity;
        GlobalVelocity.x = TargetVelocity.x;

        IsGrounded = false;

        Vector2 stepChangedPosition = GlobalVelocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(GroundNormal.y, -GroundNormal.x);
        Vector2 move = moveAlongGround * stepChangedPosition.x;

        _rigidbody2D.position = _rigidbody2D.position + move;

        Movement(move, false);
        
        move = Vector2.up * stepChangedPosition;
        
        Movement(move, true);

        // _rigidbody2D.velocity = transform.right * _speed;

        //float directionHorizontal = Input.GetAxis("Horizontal");
        //float directionVertical = Input.GetAxis("Vertical");

        //_rigidbody2D.velocity = transform.right * _speed * directionHorizontal;
        //_rigidbody2D.velocity = transform.up * _speed * directionVertical;
    }

    private void Movement(Vector2 move, bool IsDoingVerticalMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = _rigidbody2D.Cast(move, ContactFilter, HitBuffer, distance + shellRadius);
            HitBufferList.Clear();

            for (int i = 0; i < HitBufferList.Count; i++)
            {
                HitBufferList.Add(HitBuffer[i]);
            }

            for (int i = 0; i < HitBufferList.Count; i++)
            {
                Vector2 currentNormal = HitBufferList[i].normal;

                if (currentNormal.y > MinGroundNormalY)
                {
                    IsGrounded = true;

                    if (IsDoingVerticalMovement)
                    {
                        GroundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                    
                    float projection = Vector2.Dot(GlobalVelocity, currentNormal);

                    if (projection < 0)
                    {
                        GlobalVelocity = projection * currentNormal;
                    }

                    float modifiedDistance = HitBufferList[i].distance - shellRadius;

                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }
            }
        }

        _rigidbody2D.position = _rigidbody2D.position + move.normalized * distance;
    }
}
