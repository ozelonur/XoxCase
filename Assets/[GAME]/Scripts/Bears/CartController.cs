using System.Collections;
using System.Collections.Generic;
using System.IO;
using _GAME_.Scripts;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using _GAME_.Scripts.Models;
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

        [SerializeField] private string fileName = "checkout.json";

        #endregion

        #region Private Variables

        private List<CheckoutData> _checkoutData = new();

        #endregion


        public void AddProductsToTheCart(params object[] arguments)
        {
            StartCoroutine(AddToCart());
        }

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.Checkout, Checkout);
            }

            else
            {
                Unregister(CustomEvents.Checkout, Checkout);
            }
        }

        private void Checkout(object[] arguments)
        {
            SaveData();
        }

        #endregion

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

                CheckoutData data = new()
                {
                    name = product.Name,
                    Amount = product.Price,
                    ProductType = product.ProductType.ToString()
                };

                _checkoutData.Add(data);

                yield return new WaitForSeconds(.1f);
            }

            products.Clear();
        }

        private void SaveData()
        {
            ListData listData = new()
            {
                checkoutData = _checkoutData
            };

            string jsonString = JsonUtility.ToJson(listData);
            string filePath = Path.Combine("Assets/Outputs/", fileName);
            File.WriteAllText(filePath, jsonString);
            
            Debug.Log("Data Saved to " + filePath);
        }

        #endregion
    }
}