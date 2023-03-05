using _GAME_.Scripts.Enums;

namespace _GAME_.Scripts.Products
{
    public class Magazine : Product
    {
        #region MonoBehavior Methods

        private void Awake()
        {
            ProductType = ProductType.Magazine;
        }

        #endregion
    }
}