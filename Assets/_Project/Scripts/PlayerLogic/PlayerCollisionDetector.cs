using _Project.Scripts.EnvironmentResources;
using UnityEngine;

namespace _Project.Scripts.PlayerLogic
{
    [RequireComponent(typeof(ResourceMiner))]
    public class PlayerCollisionDetector : MonoBehaviour
    {
        private ResourceMiner _resourceMiner = null!;


        private void Awake()
        {
            _resourceMiner = GetComponent<ResourceMiner>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                _resourceMiner.SetResourceForMining(resource);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                _resourceMiner.ClearResourceForMining();
            }
        }
    }
}
