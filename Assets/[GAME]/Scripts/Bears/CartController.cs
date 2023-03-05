using System.Collections;
using System.Collections.Generic;
using _GAME_.Scripts;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using OrangeBear.EventSystem;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class CartController : Bear, ICart
    {
        #region Interface Implementation

        public float Amount { get; set; }

        #endregion

        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private Transform cartTransform;

        #endregion

        public void AddProductsToTheCart(params object[] arguments)
        {
            StartCoroutine(AddToCart());
        }

        #region Private Methods

        private IEnumerator AddToCart()
        {
            Queue<Product> products = PlayerManager.Instance.GetProductsFromTheHand();

            if (products == null)
            {
                yield break;
            }

            foreach (Product product in products)
            {
                Transform productTransform = product.transform;
                productTransform.parent = cartTransform;
                productTransform.localScale = Vector3.one;
                
                Amount += product.Price;
                Roar(CustomEvents.UpdateTotalCost, Amount);
                
                yield return new WaitForSeconds(.1f);
            }
            

            products.Clear();
        }

        #endregion
    }
}