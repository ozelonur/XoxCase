using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Managers;
using _GAME_.Scripts.Products;
using DG.Tweening;
using OrangeBear.EventSystem;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class ShelfController : Bear
    {
        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.AddProductToTheShelf, AddProductToTheShelf);
            }

            else
            {
                Unregister(CustomEvents.AddProductToTheShelf, AddProductToTheShelf);
            }
        }

        private void AddProductToTheShelf(object[] arguments)
        {
            ProductType productType = (ProductType)arguments[0];
            Vector3 startPosition = (Vector3)arguments[1];
            Transform parent = (Transform)arguments[2];

            Transform product = null;

            switch (productType)
            {
                case ProductType.Book:
                    Book book = PoolManager.Instance.bookPool.Get();
                    product = book.transform;
                    break;
                case ProductType.Magazine:
                    Magazine magazine = PoolManager.Instance.magazinePool.Get();
                    product = magazine.transform;
                    break;
                case ProductType.CD:
                    CompactDisk compactDisk = PoolManager.Instance.compactDiskPool.Get();
                    product = compactDisk.transform;
                    break;
                case ProductType.Food:
                    Food food = PoolManager.Instance.foodPool.Get();
                    product = food.transform;
                    break;
                default:
                    Debug.LogError("Product type is not defined!");
                    break;
            }

            product.localScale = Vector3.zero;
            product.position = startPosition;
            product.SetParent(parent);
            
            Animate(product.transform);
        }

        #endregion

        #region Private Methods

        private void Animate(Transform productTransform)
        {
            productTransform.DOScale(Vector3.one, .3f).SetEase(Ease.OutBack).SetLink(gameObject).OnComplete(() =>
            {
                productTransform.DOKill();
            });
        }

        #endregion
    }
}