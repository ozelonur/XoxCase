using _GAME_.Scripts.GlobalVariables;
using OrangeBear.Core;
using OrangeBear.Utilities;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class GameUIBear : UIBear
    {
        #region Serialized Fields

        [Header("Canvas Elements")] [SerializeField]
        private Canvas _canvas;

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            base.CheckRoarings(status);
            if (status)
            {
                Register(CustomEvents.AddProductToTheShelf, AddProductToTheShelf);
            }

            else
            {
                Register(CustomEvents.AddProductToTheShelf, AddProductToTheShelf);
            }
        }

        private void AddProductToTheShelf(object[] arguments)
        {
            StartCoroutine(CustomCoroutine.WaitOneFrame(() => Roar(CustomEvents.GetCanvasElements, _canvas)));
        }

        protected override void InitLevel(object[] arguments)
        {
            base.InitLevel(arguments);

            Roar(CustomEvents.GetCanvasElements, _canvas);
        }

        #endregion
    }
}