using _Project.Scripts.Descriptors;
using _Project.Scripts.EnvironmentResources;
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
		[Inject] 
		private ResourceDescriptorCollection _resourceDescriptorCollection = null!;
		
		private void Awake()
		{
			_gameFactory.CreatePlayer(_locationDescriptor.InitialPlayerPositionPoint);
			InitResources();
		}

		private void InitResources()
		{
			foreach (Resource resource in FindObjectsOfType<Resource>())
			{
				ResourceDescriptor descriptor = _resourceDescriptorCollection.GetDescriptorByResourceType(resource.Type);
				resource.Init(descriptor.Hp, descriptor.ItemPrefab);
			}
		}
	}
}
