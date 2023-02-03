using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Resources;
using UnityEngine;

namespace _Project.Scripts.Descriptors.Resources
{
    [CreateAssetMenu(fileName = "ItemDescriptorCollection", menuName = "Descriptors/ItemCollection", order = 0)]
    public class ItemDescriptorCollection : ScriptableObject
    {
        public List<ItemDescriptor> Descriptors = null!;

        public ItemDescriptor GetDescriptor(ItemType type)
        {
            return Descriptors.First(descriptor => descriptor.Type == type);
        }
    }
}
