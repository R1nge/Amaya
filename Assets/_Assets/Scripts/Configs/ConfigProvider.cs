using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private CardDataBundle cardDataBundle;
        public UIConfig UIConfig => uiConfig;
        public CardDataBundle CardDataBundle => cardDataBundle;
    }
}