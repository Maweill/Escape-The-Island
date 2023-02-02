using _Project.Scripts.Descriptors;
using _Project.Scripts.Descriptors.Animals;
using _Project.Scripts.Descriptors.Resources;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	[CreateAssetMenu(fileName = "Custom Installers", menuName = "Descriptor", order = 0)]
	public class DescriptorInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private PlayerDescriptor _playerDescriptor = null!;
		[SerializeField]
		private LocationDescriptor _locationDescriptor = null!;
		[SerializeField] 
		private ResourceDescriptorCollection _resourceDescriptorCollection = null!;
		[SerializeField]
		private AnimalDescriptorCollection _animalDescriptorCollection = null!;
		
		public override void InstallBindings()
		{
			Container.BindInstance(_playerDescriptor).AsSingle();
			Container.BindInstance(_locationDescriptor).AsSingle();
			Container.BindInstance(_resourceDescriptorCollection).AsSingle();
			Container.BindInstance(_animalDescriptorCollection).AsSingle();
		}
	}
}
