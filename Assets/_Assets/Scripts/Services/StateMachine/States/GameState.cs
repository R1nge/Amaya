namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LevelCreator _levelCreator;
        private readonly GoalService _goalService;

        public GameState(GameStateMachine stateMachine, LevelCreator levelCreator, GoalService goalService)
        {
            _stateMachine = stateMachine;
            _levelCreator = levelCreator;
            _goalService = goalService;
        }

        public void Enter()
        {
            _levelCreator.Create();
            _goalService.SetGoal();
        }

        public void Exit()
        {
            _levelCreator.DestroyCards();
        }
    }
}