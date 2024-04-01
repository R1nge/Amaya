using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void ChangeSprite(Sprite sprite) => spriteRenderer.sprite = sprite;
    }
}