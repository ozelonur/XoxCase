using System.Collections;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Managers;
using OrangeBear.EventSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OrangeBear.Bears
{
    public class DragAndDropController : Bear, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        #region Private Variables

        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;

        private Vector3 _startPosition;

        #endregion

        #region MonoBehavior Methods

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.GetCanvasElements, GetCanvasElements);
            }

            else
            {
                Unregister(CustomEvents.GetCanvasElements, GetCanvasElements);
            }
        }

        private void GetCanvasElements(object[] arguments)
        {
            _canvas = (Canvas)arguments[0];
        }

        #endregion

        #region Event System Methods

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = transform.position;
            _canvasGroup.alpha = .6f;
            _canvasGroup.blocksRaycasts = false;
            
            transform.SetAsLastSibling();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;

            if (!PlayerManager.Instance.IsProductCloseToCart(transform.position))
            {
                StartCoroutine(MoveToStartPosition());
            }

            else
            {
                Roar(CustomEvents.ProductTook, gameObject.GetInstanceID(), _startPosition, transform.parent);
            }
        }

        #endregion

        #region Private Methods

        private IEnumerator MoveToStartPosition()
        {
            while (Vector3.Distance(transform.position, _startPosition) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, _startPosition, 0.5f);
                yield return null;
            }
        }

        #endregion
    }
}