﻿using System.Collections.Generic;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStateMachine : GenericStateMachine<GameStateType, IState>
    {
        private GameStateMachine(GameStatesFactory gameStatesFactory)
        {
            States = new Dictionary<GameStateType, IState>
            {
                { GameStateType.Game, gameStatesFactory.CreateState(GameStateType.Game, this) },
                { GameStateType.NextLevel, gameStatesFactory.CreateState(GameStateType.NextLevel, this) },
                { GameStateType.Win, gameStatesFactory.CreateState(GameStateType.Win, this) }
            };
        }
    }
}