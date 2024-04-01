using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "New Card Data Bundle", menuName = "Configs/Card Data Bundle")]
    public class CardDataBundle : ScriptableObject
    {
        [SerializeField] private CardData[] cardData;
        public CardData[] CardData => cardData;
    }
}