using System;
using _Assets.Scripts.Services.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        public IState CreateState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Game:
                    return new GameState(gameStateMachine);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}