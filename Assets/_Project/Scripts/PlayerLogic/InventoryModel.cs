using System.Collections.Generic;
using _Project.Scripts.Descriptors.Resources;

namespace _Project.Scripts.PlayerLogic
{
    public class InventoryModel
    {
        private readonly Dictionary<ItemDescriptor, int> _items = new();

        public void AddItem(ItemDescriptor item, int quantity)
        {
            if (_items.ContainsKey(item))
            {
                _items[item] += quantity;
            }
            else
            {
                _items[item] = quantity;
            }
        }

        public void RemoveItem(ItemDescriptor item, int quantity)
        {
            if (!_items.ContainsKey(item))
            {
                return;
            }

            _items[item] -= quantity;
            if (_items[item] <= 0)
            {
                _items.Remove(item);
            }
        }

        public Dictionary<ItemDescriptor, int> Items { get { return _items; } }
    }
}