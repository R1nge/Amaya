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

        public async void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.Game);
            await _levelCreator.Create(true);
            _goalService.SetGoal();
        }

        public void Exit()
        {
            _levelCreator.DestroyCards();
        }
    }
}