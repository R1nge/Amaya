using _Assets.Scripts.Services.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    public class WinUI : MonoBehaviour
    {
        [SerializeField] private Button restart;
        [Inject] private GameStateMachine _gameStateMachine;

        private void Start() => restart.onClick.AddListener(Restart);

        private void Restart() => _gameStateMachine.SwitchState(GameStateType.Game);

        private void OnDestroy() => restart.onClick.RemoveListener(Restart);
    }
}