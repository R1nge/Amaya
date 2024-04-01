using System;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        public int Rows => rows;
        public int Columns => columns;
    }
}