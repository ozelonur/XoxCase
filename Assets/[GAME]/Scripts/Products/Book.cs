using _GAME_.Scripts.Enums;

namespace _GAME_.Scripts.Products
{
    public class Book : Product
    {
        #region MonoBehavior Methods

        private void Awake()
        {
            ProductType = ProductType.Book;
        }

        #endregion
    }
}