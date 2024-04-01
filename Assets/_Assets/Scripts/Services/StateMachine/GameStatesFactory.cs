using System;
using _Assets.Scripts.Services.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly LevelCreator _levelCreator;
        private readonly GoalService _goalService;

        private GameStatesFactory(LevelCreator levelCreator, GoalService goalService)
        {
            _levelCreator = levelCreator;
            _goalService = goalService;
        }

        public IState CreateState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Game:
                    return new GameState(gameStateMachine, _levelCreator, _goalService);
                case GameStateType.GameOver:
                    return new GameOverState(_levelCreator, _goalService);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}