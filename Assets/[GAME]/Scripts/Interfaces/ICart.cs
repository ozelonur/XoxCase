namespace _GAME_.Scripts.Interfaces
{
    public interface ICart
    {
        public float Amount { get; set; }

        void AddProductsToTheCart(params object[] arguments);
    }
}