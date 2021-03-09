using UnityEngine;
using Events;
using Game.UI;


namespace Game.Managers
{

    public class CardSorter : MonoBehaviour
    {

        [SerializeField]
        private EventListener _cardSetEventListener;

        [SerializeField]
        private Transform _cardsStack;
        
        [SerializeField]
        private Transform _cardsTaskStack;

        private void OnEnable()
        {
            _cardSetEventListener.OnEventHappened += UpdateCardsStack;
            _cardSetEventListener.OnEventHappened += UpdateTaskStack;
        }

        private void OnDisable()
        {
            _cardSetEventListener.OnEventHappened -= UpdateCardsStack;
            _cardSetEventListener.OnEventHappened -= UpdateTaskStack;
        }

        private void UpdateCardsStack()
        {
            for (int i = 0; i < _cardsStack.childCount; i++)
            {
                _cardsStack.GetChild(i).TryGetComponent<Slot>(out var slot);
                if (slot.Item != null)
                {
                    for (int j = 0; j < i; j++)
                    {
                        _cardsStack.GetChild(j).TryGetComponent<Slot>(out var emptySlot);
                        if (emptySlot.Item == null)
                        {
                            emptySlot.Item = slot.Item;
                            if(slot.transform.childCount > 0)
                            {
                                slot.transform.GetChild(0).SetParent(emptySlot.transform);
                            }
                        }
                    }
                }
                slot.CheckItem();
            }
        }

        private void UpdateTaskStack()
        {
            for (int i = 0; i < _cardsTaskStack.childCount; i++)
            {
                _cardsTaskStack.GetChild(i).TryGetComponent<Slot>(out var slot);
                if (slot.Item != null)
                {
                    for (int j = 0; j < i; j++)
                    {
                        _cardsTaskStack.GetChild(j).TryGetComponent<Slot>(out var emptySlot);
                        if (emptySlot.Item == null)
                        {
                            emptySlot.Item = slot.Item;
                            if (slot.transform.childCount > 0)
                            {
                                slot.transform.GetChild(0).SetParent(emptySlot.transform);
                            }
                        }
                    }
                }
                slot.CheckItem();
            }
        }
    }
}

