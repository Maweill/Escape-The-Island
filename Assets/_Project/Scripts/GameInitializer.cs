using _Project.Scripts.AI;
using _Project.Scripts.Descriptors;
using _Project.Scripts.Descriptors.Animals;
using _Project.Scripts.Descriptors.Resources;
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
		[Inject] 
		private AnimalDescriptorCollection _animalDescriptorCollection = null!;
		
		private void Awake()
		{
			_gameFactory.CreatePlayer(_locationDescriptor.InitialPlayerPositionPoint);
			InitResources();
			InitAnimalAreas();
		}

		private void InitResources()
		{
			foreach (Resource resource in FindObjectsOfType<Resource>())
			{
				ResourceDescriptor descriptor = _resourceDescriptorCollection.GetDescriptor(resource.Type);
				resource.Init(descriptor.Hp, descriptor.ItemPrefab);
			}
		}

		private void InitAnimalAreas()
		{
			foreach (AnimalArea animalArea in FindObjectsOfType<AnimalArea>())
			{
				AnimalDescriptor descriptor = _animalDescriptorCollection.GetDescriptor(animalArea.AnimalType);
				animalArea.Init(descriptor.AnimalPrefab, descriptor.WalkRadius, descriptor.PositionsChangeDelay, descriptor.AnimalsNumber);
			}
		}
	}
}
