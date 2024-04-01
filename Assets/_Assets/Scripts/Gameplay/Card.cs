using System;
using _Assets.Scripts.Configs;
using DG.Tweening;
using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private float tweenOffset = 0.5f;
        [SerializeField] private float tweenDuration = 0.25f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private bool _isTarget;
        private CardData _cardData;
        private Vector3 _startPosition;
        public bool IsTarget => _isTarget;
        public CardData CardData => _cardData;
        private Sequence _sequence;

        public void Init(CardData cardData)
        {
            _cardData = cardData;
            spriteRenderer.sprite = cardData.Sprite;
            _startPosition = transform.localPosition;

            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOLocalMoveX(_startPosition.x + tweenOffset, tweenDuration));
            _sequence.Append(transform.DOLocalMoveX(_startPosition.x - tweenOffset, tweenDuration));
            _sequence.Append(transform.DOLocalMoveX(_startPosition.x, tweenDuration));
            _sequence.Pause();
            _sequence.SetAutoKill(false);
        }

        public void SetTarget(bool isTarget) => _isTarget = isTarget;

        public void Interact()
        {
            if (!_isTarget)
            {
                BounceTween();
            }
            else
            {
                BounceTween();
                //TODO: add stars patricles
            }
        }

        private void BounceTween() => _sequence.Restart();

        private void OnDestroy() => _sequence.Kill();
    }
}