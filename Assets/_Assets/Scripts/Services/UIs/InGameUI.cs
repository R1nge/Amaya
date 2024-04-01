using System.Threading.Tasks;
using _Assets.Scripts.Gameplay;
using DG.Tweening;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private float fadeDuration;
        [SerializeField] private TextMeshProUGUI taskText;
        [Inject] private GoalService _goalService;

        private void Start() => _goalService.OnTargetCardChanged += OnTargetCardChanged;

        private async void OnTargetCardChanged(Card card)
        {
            if (taskText.text == string.Empty)
            {
                taskText.text = $"Find {card.CardData.Identifier}";
                await FadeIn();
            }
            else
            {
                taskText.text = $"Find {card.CardData.Identifier}";
            }
        }

        private async Task FadeIn()
        {
            await taskText.DOFade(1, fadeDuration).AsyncWaitForCompletion();
        }

        private void OnDestroy() => _goalService.OnTargetCardChanged -= OnTargetCardChanged;
    }
}