using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _Project.Scripts.AI
{
    public class AnimalArea : MonoBehaviour
    {
        [SerializeField] 
        private AnimalType _animalType;
        
        private float _walkRadius;
        private float _positionsChangeDelay;
        private GameObject _animalPrefab = null!;
        
        private readonly List<NavMeshAgent> _animalAgents = new();

        public void Init(GameObject animalPrefab, float walkRadius, float positionsChangeDelay, int animalsNumber)
        {
            _animalPrefab = animalPrefab;
            _walkRadius = walkRadius;
            _positionsChangeDelay = positionsChangeDelay;
            
            SpawnAnimals(animalsNumber);
            SetPositionsForAnimals();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _walkRadius);
        }

        private void Awake()
        {
            SetPositionsForAnimals();
        }

        private void SpawnAnimals(int animalsNumber)
        {
            for (int i = 0; i < animalsNumber; i++)
            {
                _animalAgents.Add(Instantiate(_animalPrefab, transform).GetComponent<NavMeshAgent>());
            }
        }

        private async void SetPositionsForAnimals()
        {
            while (_animalAgents.Count > 0)
            {
                foreach (NavMeshAgent animal in _animalAgents)
                {
                    Vector3 randomDirection = transform.position + Random.insideUnitSphere * _walkRadius;
                    NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _walkRadius, NavMesh.AllAreas);
                    animal.destination = hit.position;
                }
                await UniTask.Delay(TimeSpan.FromSeconds(_positionsChangeDelay));
            }
        }

        public AnimalType AnimalType
        {
            get
            {
                return _animalType;
            }
        }
    }
}
