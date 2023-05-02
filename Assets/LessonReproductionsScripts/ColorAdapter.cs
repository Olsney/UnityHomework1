using UnityEngine;

namespace LessonReproductionsScripts
{
    public class ColorAdapter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Color _targetColor;

        public void Change()
        {
            _renderer.color = _targetColor;
        }
    }
}
