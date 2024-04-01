using System;
using _Assets.Scripts.Services.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly LevelCreator _levelCreator;

        private GameStatesFactory(LevelCreator levelCreator) => _levelCreator = levelCreator;

        public IState CreateState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Game:
                    return new GameState(gameStateMachine, _levelCreator);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}