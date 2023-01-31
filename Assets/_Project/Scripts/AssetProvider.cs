using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
	[UsedImplicitly]
	public class AssetProvider
	{
		[Inject]
		private DiContainer _diContainer = null!;

		public T CreateAsset<T>(Object prefab, Vector3 position) where T : MonoBehaviour
		{
			T instance = _diContainer.InstantiatePrefab(prefab).GetComponent<T>();
			instance.transform.position = position;
			return instance;
		}
	}
}