using System.Collections.Generic;
using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class LevelCreator
    {
        private readonly ConfigProvider _configProvider;
        private readonly CardFactory _cardFactory;
        private int _currentLevel = -1;
        private readonly List<string> _usedCards = new List<string>();
        private readonly List<Card> _currentCards = new List<Card>();
        public IReadOnlyList<Card> CurrentCards => _currentCards;
        public int CurrentLevel => _currentLevel;

        private LevelCreator(ConfigProvider configProvider, CardFactory cardFactory)
        {
            _configProvider = configProvider;
            _cardFactory = cardFactory;
        }

        public void Create()
        {
            _currentLevel++;

            if (_currentLevel >= _configProvider.LevelConfig.LevelData.Length)
            {
                Debug.LogError("No more levels");
                return;
            }

            var rows = _configProvider.LevelConfig.LevelData[_currentLevel].Rows;
            var columns = _configProvider.LevelConfig.LevelData[_currentLevel].Columns;
            var cardSize = _configProvider.LevelConfig.LevelData[_currentLevel].CardSize;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var positionX = col * cardSize.x;
                    var positionY = row * cardSize.y;
                    var position = new Vector3(positionX, positionY, 10);
                    var rotation = Quaternion.identity;
                    var cardData = GetRandomCard();
                    var card = _cardFactory.Create(position, rotation, cardData);
                    _currentCards.Add(card);
                }
            }
        }

        private CardData GetRandomCard()
        {
            var index = Random.Range(0, _configProvider.CardDataBundle.CardData.Length);
            var cardData = _configProvider.CardDataBundle.CardData[index];

            if (_usedCards.Count == _configProvider.CardDataBundle.CardData.Length)
            {
                _usedCards.Clear();
                Debug.LogWarning("Level creator: All cards used");
            }

            if (_usedCards.Contains(cardData.Identifier))
            {
                return GetRandomCard();
            }

            _usedCards.Add(cardData.Identifier);
            return cardData;
        }

        public void DestroyCards()
        {
            for (int i = _currentCards.Count - 1; i >= 0; i--)
            {
                Object.Destroy(_currentCards[i].gameObject);
            }

            _usedCards.Clear();
            _currentCards.Clear();
        }

        public void Reset()
        {
            _currentLevel = -1;
        }
    }
}