using System.Collections.Generic;
using OrangeBear.Bears;
using OrangeBear.Core;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class PlayerManager : Manager<PlayerManager>
    {
        #region Private Variables

        private PlayerController _playerController;

        private Queue<Product> _productsInHand = new();

        #endregion

        #region Public Methods

        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public bool IsProductCloseToCart(Vector3 position)
        {
            return Vector3.Distance(_playerController.transform.position, position) < 10f;
        }

        public void AddProductToTheHand(Product product)
        {
            _productsInHand.Enqueue(product);
        }

        public Queue<Product> GetProductsFromTheHand()
        {
            return _productsInHand;
        }

        #endregion
    }
}