using _GAME_.Scripts.Enums;

namespace _GAME_.Scripts.Interfaces
{
    public interface IProduct
    {
        ProductType ProductType { get; }
        float Price { get; }
        string Name { get; }
        
    }
}