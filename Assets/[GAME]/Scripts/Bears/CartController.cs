using _GAME_.Scripts.Interfaces;
using OrangeBear.EventSystem;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class CartController : Bear
    {
        #region MonoBehavior Methods

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.TryGetComponent(out IPlayer player))
            {
                return;
            }

            print("Player interacted with cart");
        }

        #endregion
    }
}