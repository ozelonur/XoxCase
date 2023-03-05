using _GAME_.Scripts.Enums;

namespace _GAME_.Scripts.Products
{
    public class Magazine : Product
    {
        #region MonoBehavior Methods

        protected override void Awake()
        {
            base.Awake();
            ProductType = ProductType.Magazine;
        }

        #endregion
    }
}