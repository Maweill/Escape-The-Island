using _Project.Scripts.Descriptors;
using _Project.Scripts.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
	public class GameInitializer : MonoBehaviour
	{
		[Inject]
		private GameFactory _gameFactory = null!;
		[Inject]
		private LocationDescriptor _locationDescriptor = null!;
		
		private void Start()
		{
			_gameFactory.CreatePlayer(_locationDescriptor.InitialPlayerPositionPoint);
		}
	}
}
