using _Project.Scripts.Descriptors.Resources;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Resources
{
    [RequireComponent(typeof(Collider))]
    public class Resource : MonoBehaviour
    {
        [SerializeField] 
        private ResourceType _type;
        
        [Inject]
        private AssetProvider _assetProvider = null!;
        private const float ITEM_DROP_RADIUS = 1.5f;
        private Collider _collider;
        private float _currentHp;
        private ItemDescriptor _itemDescriptor = null!;

        public ResourceType Type { get { return _type; }}

        public void Init(float baseHp, ItemDescriptor itemDescriptor)
        {
            _currentHp = baseHp;
            _itemDescriptor = itemDescriptor;
        }
        
        public bool TryToDestroy(float damage)
        {
            _currentHp -= damage;
            Debug.Log($"Trying to destory object. name={gameObject.name}, currentHp={_currentHp}");
            PlayGetDamageAnim();

            if (_currentHp <= 0) {
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
            Destroy(gameObject);
        }

        private void SpawnResourceItem()
        {
            Vector3 randomPointInSphere = Random.insideUnitCircle * ITEM_DROP_RADIUS;
            Vector3 spawnPoint = transform.position + new Vector3(randomPointInSphere.x, 0, randomPointInSphere.z);
            Item item = _assetProvider.CreateAsset<Item>(_itemDescriptor.ItemPrefab, spawnPoint).GetComponent<Item>();
            item.Init(_itemDescriptor.Quantity);
        }

        private void PlayGetDamageAnim()
        {
            Vector3 newScale = transform.localScale;
            newScale -= new Vector3(0.05f, 0f, 0.05f);
            transform.DOScale(newScale, 0.3f);
        }
    }
}
