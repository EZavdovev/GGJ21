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

        [SerializeField]
        private bool _isBusy = false;

        public GameObject Item
        {
            get
            {
                if (transform.childCount > 0)
                {
                    return transform.GetChild(0).gameObject;
                }
                return null;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!Item)
            {
                _itemBeingDragged.value.transform.SetParent(transform);
                Debug.Log("Card set");
                _isBusy = true;
                if(_setCardDispatcher.value != null)
                {
                    _setCardDispatcher.value.Dispatch();
                }
            }
            else
            {
                _isBusy = false;
            }
        }
    }
}