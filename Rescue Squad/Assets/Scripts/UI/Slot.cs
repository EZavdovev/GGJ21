using UnityEngine;
using UnityEngine.EventSystems;
using Game.Data;
using Events;


namespace Game.UI
{

    public class Slot : MonoBehaviour, IDropHandler
    {

        [SerializeField]
        private ScriptableDispatcherValue _setCardDispatcher;

        [SerializeField]
        private ScriptableGameObjectValue _itemBeingDragged;

        private GameObject _item;

        private void OnEnable()
        {
            if (transform.childCount == 0)
            {
                return;
            }
            _item = transform.GetChild(0).gameObject;
        }

        public GameObject Item
        {
            get
            {
                if (transform.childCount > 0)
                {
                    return _item;
                }
                return null;
            }
            set 
            { 
                if(transform.childCount == 0)
                {
                    _item = value;
                }
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!Item)
            {
                _itemBeingDragged.value.transform.SetParent(transform);
                _item = _itemBeingDragged.value.gameObject;
                if(_setCardDispatcher.value != null)
                {
                    _setCardDispatcher.value.Dispatch();
                }
            }
        }

        public void CheckItem()
        {
            if(transform.childCount == 0)
            {
                Item = null;
            }
        }
    }
}