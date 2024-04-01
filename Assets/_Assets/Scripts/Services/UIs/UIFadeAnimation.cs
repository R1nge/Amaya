using DG.Tweening;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public class UIFadeAnimation : MonoBehaviour
    {
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private CanvasGroup canvasGroup;

        public void FadeIn() => canvasGroup.DOFade(1, duration);

        public void FadeOut() => canvasGroup.DOFade(0, duration);

        private void OnDestroy() => canvasGroup.DOKill();
    }
}