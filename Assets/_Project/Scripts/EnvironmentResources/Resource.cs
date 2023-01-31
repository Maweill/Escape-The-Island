using _Project.Scripts.Descriptors;
using UnityEngine;

namespace _Project.Scripts.EnvironmentResources
{
    [RequireComponent(typeof(Collider))]
    public class Resource : MonoBehaviour
    {
        [SerializeField] 
        private ResourceTypes _resourceType;

        private Collider _collider;

        private float _currentHp;
        private GameObject _resourceItemPrefab;


        public void Init(ResourceDescriptorCollection resourceDescriptorCollection)
        {
            ResourceDescriptor resourceDescriptor = resourceDescriptorCollection.GetDescriptorByResourceType(_resourceType);
            _currentHp = resourceDescriptor.ResourceHp;
            _resourceItemPrefab = resourceDescriptor.ResourceItemPrefab;
        }
        
        public bool TryToDestroy(float damage)
        {
            _currentHp -= damage;
            Debug.Log(gameObject.name + " current hp: " + _currentHp);
            
            if (_currentHp <= 0)
            {
                Die();
                return true;
            }

            return false;
        }

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void Die()
        {
            SpawnResourceItem();
            _collider.enabled = false;
            Destroy(gameObject, 0.5f);
        }

        private void SpawnResourceItem()
        {
            Instantiate(_resourceItemPrefab, transform.position, Quaternion.identity);
        }
    }
}
