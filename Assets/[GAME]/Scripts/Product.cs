using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using DG.Tweening;
using OrangeBear.EventSystem;
using TMPro;
using UnityEngine;

namespace _GAME_.Scripts
{
    public abstract class Product : Bear, IProduct
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private TMP_Text nameText;

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

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.ProductTook, ProductTook);
            }

            else
            {
                Unregister(CustomEvents.ProductTook, ProductTook);
            }
        }

        private void ProductTook(object[] arguments)
        {
            int hash = (int)arguments[0];
            Vector3 startPosition = (Vector3)arguments[1];
            Transform parent = (Transform)arguments[2];


            if (hash != gameObject.GetInstanceID())
            {
                return;
            }

            transform.DOScale(Vector3.zero, .3f).SetEase(Ease.InBack).SetLink(gameObject).OnComplete(() =>
            {
                Roar(CustomEvents.AddProductToTheShelf, ProductType, startPosition, parent);
                PlayerManager.Instance.AddProductToTheHand(this);
                transform.DOKill();
            });
        }

        #endregion
    }
}