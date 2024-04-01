using System;
using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly LevelCreator _levelCreator;
        private readonly GoalService _goalService;
        private readonly ConfigProvider _configProvider;
        private readonly UIStateMachine _uiStateMachine;

        private GameStatesFactory(LevelCreator levelCreator, GoalService goalService, ConfigProvider configProvider, UIStateMachine uiStateMachine)
        {
            _levelCreator = levelCreator;
            _goalService = goalService;
            _configProvider = configProvider;
            _uiStateMachine = uiStateMachine;
        }

        public IState CreateState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Game:
                    return new GameState(gameStateMachine, _levelCreator, _goalService, _uiStateMachine);
                case GameStateType.NextLevel:
                    return new NextLevelState(gameStateMachine, _levelCreator, _goalService, _configProvider);
                case GameStateType.Win:
                    return new WinState(_levelCreator, _goalService, _uiStateMachine);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}