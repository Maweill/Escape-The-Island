using UnityEngine;

namespace _Project.Scripts.Resources
{
    public class Item : MonoBehaviour
    {
        [SerializeField] 
        private ItemType _type;

        public int Quantity { get; private set; }

        public void Init(int quantity)
        {
            Quantity = quantity;
        }

        public void Collect()
        {
            // TODO Возможна анимация перемещения предмета к герою
            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        public ItemType Type { get { return _type; } }
    }
}