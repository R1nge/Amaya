using System;
using System.Collections.Generic;
using _Assets.Scripts.Gameplay;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Assets.Scripts.Services
{
    public class GoalService
    {
        private readonly LevelCreator _levelCreator;
        private Card _targetCard;
        public Card TargetCard => _targetCard;
        private readonly List<string> _usedCards = new List<string>();

        public event Action<Card> OnTargetCardChanged;

        private GoalService(LevelCreator levelCreator)
        {
            _levelCreator = levelCreator;
        }

        public void SetGoal()
        {
            if (_levelCreator.CurrentCards.Count == 0)
            {
                Debug.LogWarning("Goal service: No cards to select from");
                return;
            }

            var index = GetIndex();
            _targetCard = _levelCreator.CurrentCards[index];
            _targetCard.SetTarget(true);
            OnTargetCardChanged?.Invoke(TargetCard);
        }

        private int GetIndex()
        {
            var index = Random.Range(0, _levelCreator.CurrentCards.Count);
            var card = _levelCreator.CurrentCards[index];

            if (_usedCards.Contains(card.CardData.Identifier))
            {
                return GetIndex();
            }

            _usedCards.Add(card.CardData.Identifier);
            return index;
        }

        public void ResetGoal()
        {
            _targetCard.SetTarget(false);
            _targetCard = null;
            _usedCards.Clear();
        }
    }
}