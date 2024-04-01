using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Level Config", menuName = "Configs/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private LevelData[] levelData;
        public LevelData[] LevelData => levelData;
    }
}