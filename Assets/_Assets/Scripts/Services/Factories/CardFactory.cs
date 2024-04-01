using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class CardFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private CardFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }
        
        public Card Create(Vector3 position, Quaternion rotation, Sprite sprite)
        {
            var card = _objectResolver.Instantiate(_configProvider.CardPrefab, position, rotation);
            card.ChangeSprite(sprite);
            return card;
        }
    }
}