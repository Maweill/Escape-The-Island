using System.Collections.Generic;
using _Project.Scripts.Descriptors.Resources;
using _Project.Scripts.Logger;

namespace _Project.Scripts.PlayerLogic
{
    public class InventoryModel
    {
        private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<InventoryModel>();
        
        private readonly Dictionary<ResourceItemDescriptor, int> _items = new();

        public void AddItem(ResourceItemDescriptor resourceItem, int quantity)
        {
            if (_items.ContainsKey(resourceItem))
            {
                _items[resourceItem] += quantity;
            }
            else
            {
                _items[resourceItem] = quantity;
            }
        }

        public void RemoveItem(ResourceItemDescriptor resourceItem, int quantity)
        {
            if (_items[resourceItem] < quantity)
            {
                _logger.Warn($"Trying to remove more items than in inventory. name={resourceItem.Name}");
            }
            
            _items[resourceItem] -= quantity;
            if (_items[resourceItem] <= 0)
            {
                _items.Remove(resourceItem);
            }
        }

        public Dictionary<ResourceItemDescriptor, int> Items { get { return _items; } }
    }
}
