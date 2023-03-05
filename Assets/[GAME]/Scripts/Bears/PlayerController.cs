using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using OrangeBear.EventSystem;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class PlayerController : Bear
    {
        #region MonoBehavior Methods

        private void Awake()
        {
            PlayerManager.Instance.SetPlayerController(this);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.TryGetComponent(out ICart cart))
            {
                return;
            }

            cart.AddProductsToTheCart();
        }

        #endregion
    }
}