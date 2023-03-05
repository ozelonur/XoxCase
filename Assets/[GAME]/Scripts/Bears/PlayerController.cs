using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _GAME_.Scripts;
using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using OrangeBear.EventSystem;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class PlayerController : Bear, IPlayer
    {
        #region MonoBehavior Methods

        private void Awake()
        {
            PlayerManager.Instance.SetPlayerController(this);
        }

        #endregion
        public void InteractedWithCart(params object[] arguments)
        {
            Transform parent = (Transform)arguments[0];

            StartCoroutine(AddToCart(parent));
        }

        #region Private Methods

        private IEnumerator AddToCart(Transform parent)
        {
            
            Queue<Product> product = PlayerManager.Instance.GetProductsFromTheHand();
            
            if (product == null)
            {
                yield break;
            }
            
            foreach (Transform productInHandTransform in product.Select(productInHand => productInHand.transform))
            {
                productInHandTransform.parent = parent;
                productInHandTransform.localScale = Vector3.one;
                yield return new WaitForSeconds(.1f);
            }
            
            product.Clear();
        }

        #endregion
    }
}