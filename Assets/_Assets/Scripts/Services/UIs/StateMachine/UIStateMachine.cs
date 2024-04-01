using System.Collections.Generic;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStateMachine : GenericStateMachine<UIStateType, IState>
    {
        private UIStateMachine(UIStatesFactory uiStatesFactory)
        {
            States = new Dictionary<UIStateType, IState>
            {
                { UIStateType.Game, uiStatesFactory.CreateState(UIStateType.Game, this) },
                { UIStateType.Win, uiStatesFactory.CreateState(UIStateType.Win, this) }
            };
            
        }
    }
}