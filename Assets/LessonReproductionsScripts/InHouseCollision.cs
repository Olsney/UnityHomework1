using UnityEngine;
using UnityEngine.Events;

namespace Scripts__Personal_
{
    public class InHouseCollision : MonoBehaviour
    {
        //[SerializeField] private UnityEvent _houseEntered;
        //[SerializeField] private UnityEvent _houseAbonded;
        //[SerializeField] private AudioSource _audioSource;

        //public event UnityAction InHouseEntered
        //{
        //    add => _houseEntered.AddListener(value);
        //    remove => _houseEntered.RemoveListener(value);
        //}

        //public event UnityAction HouseAbonded
        //{
        //    add => _houseAbonded.AddListener(value);
        //    remove => _houseAbonded.RemoveListener(value);
        //}

        public event UnityAction HouseEntered;
        public event UnityAction HouseAbonded;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                HouseEntered.Invoke();
            }
        }
    
        public void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                HouseAbonded.Invoke();
            }
        }
    }
}