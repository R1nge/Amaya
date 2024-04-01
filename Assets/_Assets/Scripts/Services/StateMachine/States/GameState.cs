namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LevelCreator _levelCreator;

        public GameState(GameStateMachine stateMachine, LevelCreator levelCreator)
        {
            _stateMachine = stateMachine;
            _levelCreator = levelCreator;
        }

        public void Enter()
        {
            _levelCreator.Create();
        }

        public void Exit()
        {
            _levelCreator.Reset();
        }
    }
}