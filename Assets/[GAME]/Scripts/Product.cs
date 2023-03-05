using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Interfaces;
using OrangeBear.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts
{
    public abstract class Product : Bear, IProduct
    {
        public ProductType ProductType { get; protected set; }
        [field: SerializeField] public float Price { get; set; }
        [field: SerializeField] public string Name { get; set; }
    }
}