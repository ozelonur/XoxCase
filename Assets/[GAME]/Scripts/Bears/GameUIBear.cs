using _GAME_.Scripts.GlobalVariables;
using DG.Tweening;
using OrangeBear.Core;
using OrangeBear.Utilities;
using TMPro;
using UnityEngine;

namespace OrangeBear.Bears
{
    public class GameUIBear : UIBear
    {
        #region Serialized Fields

        [Header("Canvas Elements")] [SerializeField]
        private Canvas _canvas;

        [Header("Components")] [SerializeField]
        private TMP_Text costText;

        #endregion

        #region Private Variables

        private float _oldCost;

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            base.CheckRoarings(status);
            if (status)
            {
                Register(CustomEvents.AddProductToTheShelf, AddProductToTheShelf);
                Register(CustomEvents.UpdateTotalCost, UpdateTotalCost);
            }

            else
            {
                Register(CustomEvents.AddProductToTheShelf, AddProductToTheShelf);
                Register(CustomEvents.UpdateTotalCost, UpdateTotalCost);
            }
        }

        private void UpdateTotalCost(object[] arguments)
        {
            float cost = (float)arguments[0];

            DOTween.Kill("CostUpdateTween", true);
            DOTween.To(() => _oldCost, x => _oldCost = x, cost, 0.5f).OnUpdate(() =>
                {
                    costText.text = "COST : ₺" + _oldCost.ToString("F2");
                })
                .OnComplete(() =>
                {
                    _oldCost = cost;
                }).SetId("CostUpdateTween");
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