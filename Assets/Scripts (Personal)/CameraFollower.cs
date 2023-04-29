using UnityEngine;

namespace Scripts__Personal_
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothing = 3f;
        
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offset, _smoothing * Time.deltaTime);

            transform.position = nextPosition;
        }
    }
}