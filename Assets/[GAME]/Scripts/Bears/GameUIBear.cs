using _GAME_.Scripts.GlobalVariables;
using OrangeBear.Core;
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

        protected override void InitLevel(object[] arguments)
        {
            base.InitLevel(arguments);
            
            Roar(CustomEvents.GetCanvasElements, _canvas);
        }

        #endregion
    }
}

