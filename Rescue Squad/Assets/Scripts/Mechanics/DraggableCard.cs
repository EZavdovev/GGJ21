using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Mechanics
{

    public class DraggableCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private RectTransform _rectTransform;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}

