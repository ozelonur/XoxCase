using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using OrangeBear.EventSystem;

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
            
        }
    }
}