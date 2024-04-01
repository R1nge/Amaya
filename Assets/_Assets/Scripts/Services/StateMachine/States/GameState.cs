using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LevelCreator _levelCreator;
        private readonly GoalService _goalService;
        private readonly UIStateMachine _uiStateMachine;

        public GameState(GameStateMachine stateMachine, LevelCreator levelCreator, GoalService goalService, UIStateMachine uiStateMachine)
        {
            _stateMachine = stateMachine;
            _levelCreator = levelCreator;
            _goalService = goalService;
            _uiStateMachine = uiStateMachine;
        }

        public void Enter()
        {
            //TODO: create with animation
            _uiStateMachine.SwitchState(UIStateType.Game);
            _levelCreator.Create();
            _goalService.SetGoal();
        }

        public void Exit()
        {
            _levelCreator.DestroyCards();
        }
    }
}