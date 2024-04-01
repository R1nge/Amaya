using _Assets.Scripts.Services.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    [RequireComponent(typeof(UIFadeAnimation))]
    public class WinUI : MonoBehaviour
    {
        [SerializeField] private Button restart;
        [SerializeField] private UIFadeAnimation uiFadeAnimation;
        [Inject] private GameStateMachine _gameStateMachine;

        private void Start()
        {
            uiFadeAnimation.FadeIn();
            restart.onClick.AddListener(Restart);
        }

        private void Restart() => _gameStateMachine.SwitchState(GameStateType.Game);

        private void OnDestroy() => restart.onClick.RemoveListener(Restart);
    }
}