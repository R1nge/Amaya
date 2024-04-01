using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class WinState : IState
    {
        private readonly LevelCreator _levelCreator;
        private readonly GoalService _goalService;
        private readonly UIStateMachine _uiStateMachine;

        public WinState(LevelCreator levelCreator, GoalService goalService, UIStateMachine uiStateMachine)
        {
            _levelCreator = levelCreator;
            _goalService = goalService;
            _uiStateMachine = uiStateMachine;
        }

        public void Enter()
        {
            _levelCreator.Reset();
            _goalService.ResetGoal();
            _uiStateMachine.SwitchState(UIStateType.Win);
        }

        public void Exit()
        {
        }
    }
}