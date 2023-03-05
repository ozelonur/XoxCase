using _GAME_.Scripts.Products;
using OrangeBear.Core;
using OrangeBear.EventSystem;
using OrangeBear.Utilities;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class PoolManager : Manager<PoolManager>
    {
        #region Serialized Fields

        [Header("Prefabs")] [SerializeField] private Book bookPrefab;
        [SerializeField] private Food foodPrefab;
        [SerializeField] private CompactDisk compactDiskPrefab;
        [SerializeField] private Magazine magazinePrefab;

        [Header("Pool Parents")] [SerializeField]
        private Transform bookPoolParent;

        [SerializeField] private Transform foodPoolParent;
        [SerializeField] private Transform compactDiskPoolParent;
        [SerializeField] private Transform magazinePoolParent;

        #endregion

        #region Public Methods

        public CustomObjectPool<Book> bookPool;
        public CustomObjectPool<Food> foodPool;
        public CustomObjectPool<CompactDisk> compactDiskPool;
        public CustomObjectPool<Magazine> magazinePool;

        #endregion

        #region MonoBehavior Methods

        private void Awake()
        {
            bookPool = new CustomObjectPool<Book>(bookPrefab, 50, bookPoolParent);
            foodPool = new CustomObjectPool<Food>(foodPrefab, 50, foodPoolParent);
            compactDiskPool = new CustomObjectPool<CompactDisk>(compactDiskPrefab, 50, compactDiskPoolParent);
            magazinePool = new CustomObjectPool<Magazine>(magazinePrefab, 50, magazinePoolParent);
        }

        #endregion
    }
}