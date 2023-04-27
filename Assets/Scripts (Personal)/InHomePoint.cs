using UnityEngine;
using UnityEngine.Events;
public class InHomePoint : MonoBehaviour
{
    public event UnityAction HouseEntered;
    public event UnityAction HouseAbonded;
    
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _reachedColor;
    [SerializeField] Animator _animator;

    private const string IsEnter = "IsEnter";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool(IsEnter, true);
            HouseEntered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool(IsEnter, false);
            HouseAbonded?.Invoke();
        }
    }
}