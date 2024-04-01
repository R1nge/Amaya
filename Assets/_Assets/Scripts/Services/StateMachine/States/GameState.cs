namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public GameState(GameStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Enter() { }

        public void Exit() { }
    }
}