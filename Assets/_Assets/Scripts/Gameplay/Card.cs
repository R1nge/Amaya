using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private bool _isTarget;
        public bool IsTarget => _isTarget;

        public void ChangeSprite(Sprite sprite) => spriteRenderer.sprite = sprite;
        
        public void SetTarget(bool isTarget) => _isTarget = isTarget;

        public void Interact()
        {
            //TODO: play tween
        }
    }
}