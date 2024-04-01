using _Assets.Scripts.Gameplay;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class GoalService
    {
        private readonly LevelCreator _levelCreator;
        private Card _targetCard;

        private GoalService(LevelCreator levelCreator)
        {
            _levelCreator = levelCreator;
        }

        public void SetGoal()
        {
            var index = Random.Range(0, _levelCreator.CurrentCards.Count);
            _targetCard = _levelCreator.CurrentCards[index];
            _targetCard.SetTarget(true);
        }

        public void ResetGoal()
        {
            _targetCard.SetTarget(false);
            _targetCard = null;
        }
    }
}