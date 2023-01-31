using System;
using _Project.Scripts.EnvironmentResources;
using UnityEngine;

namespace _Project.Scripts.Descriptors
{
    [CreateAssetMenu(fileName = "ResourceDescriptorCollection", menuName = "Descriptors/ResourceCollection", order = 0)]
    public class ResourceDescriptorCollection : ScriptableObject
    {
        public ResourceDescriptor TreeDescriptor;
        public ResourceDescriptor RockDescriptor;


        public ResourceDescriptor GetDescriptorByResourceType(ResourceTypes resourceType)
        {
            switch (resourceType)
            {
                case ResourceTypes.Tree:
                    return TreeDescriptor;
                case ResourceTypes.Rock:
                    return RockDescriptor;
            }

            throw new ArgumentException(message: "Некорректный тип ресурса");
        }
    }
}
