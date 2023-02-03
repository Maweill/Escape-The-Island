using _Project.Scripts.Resources;
using UnityEngine;

namespace _Project.Scripts.Descriptors.Resources
{
    [CreateAssetMenu(fileName = "ItemDescriptor", menuName = "Descriptors/Item", order = 0)]
    public class ItemDescriptor : ScriptableObject
    {
        public ItemType Type;
        public GameObject ItemPrefab = null!;
        public int Quantity;
        public string Name = null!;
    }
}
