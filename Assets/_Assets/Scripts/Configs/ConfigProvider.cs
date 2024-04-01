using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private CardDataBundle cardDataBundle;
        [SerializeField] private LevelConfig levelConfig;
        public UIConfig UIConfig => uiConfig;
        public CardDataBundle CardDataBundle => cardDataBundle;
        public LevelConfig LevelConfig => levelConfig;
    }
}