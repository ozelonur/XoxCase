using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Interfaces;
using OrangeBear.EventSystem;
using TMPro;
using UnityEngine;

namespace _GAME_.Scripts
{
    public abstract class Product : Bear, IProduct
    {
        #region Serialized Fields

        [Header("Components")]
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text priceText;

        #endregion
        public ProductType ProductType { get; protected set; }
        [field: SerializeField] public float Price { get; set; }
        [field: SerializeField] public string Name { get; set; }

        #region MonoBehavior Methods

        protected virtual void Awake()
        {
            nameText.text = Name;
            priceText.text = "₺" + Price;
        }

        #endregion
    }
}