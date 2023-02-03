using _Project.Scripts.Resources;
using UnityEngine;

namespace _Project.Scripts.Descriptors.Resources
{
    [CreateAssetMenu(fileName = "ResourceDescriptor", menuName = "Descriptors/Resource", order = 0)]
    public class ResourceDescriptor : ScriptableObject
    {
        public ResourceType ResourceType;
        public ItemDescriptor ItemDescriptor = null!;
        public float Hp;
    }
}
