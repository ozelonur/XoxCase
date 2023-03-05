using _GAME_.Scripts.Enums;

namespace _GAME_.Scripts.Products
{
    public class Book : Product
    {
        #region MonoBehavior Methods

        protected override void Awake()
        {
            base.Awake();
            ProductType = ProductType.Book;
        }

        #endregion
    }
}