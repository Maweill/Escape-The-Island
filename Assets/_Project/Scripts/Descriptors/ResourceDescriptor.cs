using _Project.Scripts.EnvironmentResources;
using UnityEngine;

namespace _Project.Scripts.Descriptors
{
    [CreateAssetMenu(fileName = "ResourceDescriptor", menuName = "Descriptors/Resource", order = 0)]
    public class ResourceDescriptor : ScriptableObject
    {
        public GameObject ItemPrefab = null!;
        public float Hp;
        public ResourceType ResourceType;
    }
}
