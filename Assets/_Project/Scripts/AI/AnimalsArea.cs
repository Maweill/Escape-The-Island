using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _Project.Scripts.AI
{
    public class AnimalsArea : MonoBehaviour
    {
        [SerializeField] 
        private float _walkRadius;
        [SerializeField] 
        private float _positionsChangeDelay;
        [SerializeField] 
        private List<NavMeshAgent> _animals;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _walkRadius);
        }

        private void Awake()
        {
            SetPositionsForAnimals();
        }

        private async void SetPositionsForAnimals()
        {
            while (_animals.Count > 0)
            {
                foreach (NavMeshAgent animal in _animals)
                {
                    Vector3 randomDirection = transform.position + Random.insideUnitSphere * _walkRadius;
                    NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _walkRadius, NavMesh.AllAreas);
                    animal.destination = hit.position;
                }
                await UniTask.Delay(TimeSpan.FromSeconds(_positionsChangeDelay));
            }
        }
    }
}
