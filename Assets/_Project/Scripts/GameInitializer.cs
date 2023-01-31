using _Project.Scripts.Descriptors;
using _Project.Scripts.EnvironmentResources;
using _Project.Scripts.Factories;
using UnityEngine;
using Zenject;
using System.Linq;

namespace _Project.Scripts
{
	public class GameInitializer : MonoBehaviour
	{
		[Inject]
		private GameFactory _gameFactory = null!;
		[Inject]
		private LocationDescriptor _locationDescriptor = null!;
		[Inject] 
		private ResourceDescriptorCollection _resourceDescriptorCollection = null!;
		
		private void Awake()
		{
			CreatePlayer();
			InitResources();
		}

		private void CreatePlayer()
		{
			_gameFactory.CreatePlayer(_locationDescriptor.InitialPlayerPositionPoint);
		}

		private void InitResources()
		{
			FindObjectsOfType<Resource>().ToList().ForEach(resource => resource.Init(_resourceDescriptorCollection));
		}
	}
}
