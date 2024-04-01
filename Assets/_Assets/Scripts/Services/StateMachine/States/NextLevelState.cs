using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class NextLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly LevelCreator _levelCreator;
        private readonly GoalService _goalService;
        private readonly ConfigProvider _configProvider;

        public NextLevelState(GameStateMachine gameStateMachine, LevelCreator levelCreator, GoalService goalService, ConfigProvider configProvider)
        {
            _gameStateMachine = gameStateMachine;
            _levelCreator = levelCreator;
            _goalService = goalService;
            _configProvider = configProvider;
        }

        public async void Enter()
        {
            if (_levelCreator.CurrentLevel == _configProvider.LevelConfig.LevelData.Length - 1)
            {
                Debug.Log("Switching to Win state");
                _gameStateMachine.SwitchState(GameStateType.Win);
                return;
            }

            await _levelCreator.Create();
            _goalService.SetGoal();
        }

        public void Exit()
        {
            _levelCreator.DestroyCards();
        }
    }
}