using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private bool _isTarget;
        private CardData _cardData;
        public bool IsTarget => _isTarget;
        public CardData CardData => _cardData;

        public void Init(CardData cardData)
        {
            _cardData = cardData;
            spriteRenderer.sprite = cardData.Sprite;
        }

        public void SetTarget(bool isTarget) => _isTarget = isTarget;

        public void Interact()
        {
            //TODO: play tween
        }
    }
}