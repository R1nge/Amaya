using System;
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
            
            var index = Random.Range(0, _levelCreator.CurrentCards.Count);
            _targetCard = _levelCreator.CurrentCards[index];
            _targetCard.SetTarget(true);
            OnTargetCardChanged?.Invoke(TargetCard);
        }

        public void ResetGoal()
        {
            _targetCard.SetTarget(false);
            _targetCard = null;
        }
    }
}