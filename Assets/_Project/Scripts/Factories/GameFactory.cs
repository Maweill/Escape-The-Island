using System.Collections.Generic;
using _Project.Scripts.Descriptors;
using _Project.Scripts.PlayerLogic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Factories
{
	[UsedImplicitly]
	public class GameFactory
	{
		[Inject]
		private AssetProvider _assetProvider = null!;
		[Inject]
		private PlayerDescriptor _playerDescriptor = null!;
		
		public GameObject Player { get; private set; } = null!;

		public GameObject CreatePlayer(Vector3 position)
		{
			GameObject player = _assetProvider.CreateAsset<PlayerMovement>(_playerDescriptor.Prefab, position).gameObject;
			Player = player;
			return player;
		}
		
		public void ClearAll()
		{
			Object.Destroy(Player.gameObject);
		}
	}
}
