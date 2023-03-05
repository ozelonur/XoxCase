using _GAME_.Scripts.Interfaces;
using OrangeBear.EventSystem;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class CartController : Bear
    {
        #region Serialized Fields

        [Header("Components")]
        [SerializeField] private Transform cartTransform;
        #endregion
        #region MonoBehavior Methods

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.TryGetComponent(out IPlayer player))
            {
                return;
            }

            player.InteractedWithCart(cartTransform);
        }

        #endregion
    }
}