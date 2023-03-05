using _GAME_.Scripts.Enums;

namespace _GAME_.Scripts.Products
{
    public class CompactDisk : Product
    {
        #region MonoBehavior Methods

        private void Awake()
        {
            ProductType = ProductType.CD;
        }

        #endregion
    }
}