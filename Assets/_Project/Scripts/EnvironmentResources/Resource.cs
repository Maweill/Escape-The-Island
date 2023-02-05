using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.EnvironmentResources
{
    [RequireComponent(typeof(Collider))]
    public class Resource : MonoBehaviour
    {
        [SerializeField] 
        private ResourceType _type;
        
        private Collider _collider;
        private float _currentHp;
        private GameObject _resourceItemPrefab = null!;

        public ResourceType Type { get { return _type; }}

        public void Init(float baseHp, GameObject itemPrefab)
        {
            _currentHp = baseHp;
            _resourceItemPrefab = itemPrefab;
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
            Instantiate(_resourceItemPrefab, transform.position, Quaternion.identity);
        }

        private void PlayGetDamageAnim()
        {
            Vector3 newScale = transform.localScale;
            newScale -= new Vector3(0.05f, 0f, 0.05f);
            transform.DOScale(newScale, 0.3f);
        }
    }
}