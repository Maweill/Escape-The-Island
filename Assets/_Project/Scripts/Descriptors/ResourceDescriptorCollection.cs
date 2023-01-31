using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.EnvironmentResources;
using UnityEngine;

namespace _Project.Scripts.Descriptors
{
    [CreateAssetMenu(fileName = "ResourceDescriptorCollection", menuName = "Descriptors/ResourceCollection", order = 0)]
    public class ResourceDescriptorCollection : ScriptableObject
    {
        public List<ResourceDescriptor> Descriptors = null!;


        public ResourceDescriptor GetDescriptorByResourceType(ResourceType resourceType)
        {
            return Descriptors.First(descriptor => descriptor.ResourceType == resourceType);
        }
    }
}
