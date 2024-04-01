namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameOverState : IState
    {
        private readonly LevelCreator _levelCreator;
        private readonly GoalService _goalService;

        public GameOverState(LevelCreator levelCreator, GoalService goalService)
        {
            _levelCreator = levelCreator;
            _goalService = goalService;
        }

        public void Enter()
        {
            _levelCreator.Reset();
            _goalService.ResetGoal();
        }

        public void Exit()
        {
        }
    }
}