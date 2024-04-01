using _Assets.Scripts.Services.StateMachine;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class Raycaster : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [Inject] private GameStateMachine _gameStateMachine;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var rayHit = Physics2D.GetRayIntersection(camera.ScreenPointToRay(Input.mousePosition));

                if (rayHit.collider == null)
                {
                    return;
                }

                if (rayHit.collider.TryGetComponent(out Card card))
                {
                    card.Interact();

                    if (card.IsTarget)
                    {
                        _gameStateMachine.SwitchState(GameStateType.NextLevel);
                    }
                }
            }
        }
    }
}