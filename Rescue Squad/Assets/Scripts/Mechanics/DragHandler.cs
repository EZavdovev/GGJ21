using UnityEngine;
using UnityEngine.EventSystems;
using Game.Data;


namespace Game.Mechanics
{

    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        [SerializeField]
        private ScriptableGameObjectValue _objectToDrag;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        private Vector3 _startPos;

        [SerializeField]
        private Transform _startParent;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _objectToDrag.value = gameObject;
            _startPos = transform.position;
            _startParent = transform.parent;
            _canvasGroup.blocksRaycasts = false;
            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
            transform.SetParent(_startParent.parent);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _objectToDrag.value = null;
            if (transform.parent == _startParent || transform.parent == _startParent.parent)
            {
                transform.position = _startPos;
                transform.SetParent(_startParent);
            }
            _canvasGroup.blocksRaycasts = true;
        }
    }
}