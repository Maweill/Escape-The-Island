using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.AI;
using UnityEngine;

namespace _Project.Scripts.Descriptors.Animals
{
    [CreateAssetMenu(fileName = "AnimalDescriptorCollection", menuName = "Descriptors/AnimalCollection", order = 0)]
    public class AnimalDescriptorCollection : ScriptableObject
    {
        public List<AnimalDescriptor> Descriptors = null!;
        
        public AnimalDescriptor GetDescriptor(AnimalType animalType)
        {
            return Descriptors.First(descriptor => descriptor.AnimalType == animalType);
        }
    }
}