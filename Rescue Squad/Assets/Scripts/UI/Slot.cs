using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Data;


namespace Game.UI
{

    public class Slot : MonoBehaviour, IDropHandler
    {

        [SerializeField]
        private ScriptableDispatcherValue _setCardDispatcher;

        [SerializeField]
        private ScriptableGameObjectValue _itemBeingDragged;

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
                _setCardDispatcher.value.Dispatch();
            }
        }
    }
}