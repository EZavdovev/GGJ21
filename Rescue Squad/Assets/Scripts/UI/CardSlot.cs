using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Data;

namespace Game.UI
{

    public class CardSlot : MonoBehaviour, IDropHandler
    {

        [SerializeField]
        private ScriptableVector2 _rectTransformKeeper;

        public void OnDrop(PointerEventData eventData)
        {
            if(eventData.pointerDrag != null) // Он всегда не нулл, надо переделать
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _rectTransformKeeper.value;
            }
        }
    }
}
