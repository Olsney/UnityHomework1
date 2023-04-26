using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InHomePoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _reachedColor;
    [SerializeField] Animator _animator;

    private const string IsEnter = "IsEnter";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool(IsEnter, true);
            
        }
    }

    private void OnTriggerStay()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool(IsEnter, false);
        }
    }
}