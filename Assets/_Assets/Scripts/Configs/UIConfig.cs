using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "Configs/UI")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private GameObject gameUI;
        [SerializeField] private GameObject winUI;
        public GameObject GameUI => gameUI;
        public GameObject WinUI => winUI;
    }
}