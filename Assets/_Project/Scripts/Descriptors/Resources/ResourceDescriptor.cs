using _Project.Scripts.EnvironmentResources;
using UnityEngine;

namespace _Project.Scripts.Descriptors.Resources
{
    [CreateAssetMenu(fileName = "ResourceDescriptor", menuName = "Descriptors/Resource", order = 0)]
    public class ResourceDescriptor : ScriptableObject
    {
        public ResourceType ResourceType;
        public GameObject ItemPrefab = null!;
        public float Hp;
    }
}
