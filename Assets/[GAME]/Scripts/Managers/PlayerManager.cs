using OrangeBear.Bears;
using OrangeBear.Core;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class PlayerManager : Manager<PlayerManager>
    {
        #region Private Variables

        private PlayerController _playerController;

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

        #endregion
    }
}