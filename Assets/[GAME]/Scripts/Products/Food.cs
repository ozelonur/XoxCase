using _GAME_.Scripts.Enums;

namespace _GAME_.Scripts.Products
{
    public class Food : Product
    {
        #region MonoBehavior Methods

        protected override void Awake()
        {
            base.Awake();
            ProductType = ProductType.Food;
        }

        #endregion
    }
}