using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UIGameWinState : IState
    {
        private readonly UIFactory _uiFactory;
        private GameObject _ui;

        public UIGameWinState(UIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _ui = _uiFactory.CreateUI(UIStateType.Win);

        public void Exit() => Object.Destroy(_ui);
    }
}