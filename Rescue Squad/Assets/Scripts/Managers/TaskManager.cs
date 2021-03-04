using Events;
using Game.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{

    public class TaskManager : MonoBehaviour
    {

        [SerializeField]
        private EventListener _setCardEventListener;

        [SerializeField]
        private EventListener _taskEndedEventListener;

        [SerializeField]
        private ScriptableTaskValue _currentTask;

        [SerializeField]
        private ScriptableTaskValue _endedTask;

        [SerializeField]
        private Transform _cardsStack;

        [SerializeField]
        private GameObject _slotPrefab;

        [SerializeField]
        private GameObject _cardPrefab;

        [SerializeField]
        private Transform _cardsPanel;


        private void OnEnable()
        {
            _setCardEventListener.OnEventHappened += LoadCards;
            _taskEndedEventListener.OnEventHappened += ReturnCards;
        }

        private void OnDisable()
        {
            _setCardEventListener.OnEventHappened -= LoadCards;
            _taskEndedEventListener.OnEventHappened -= ReturnCards;
        }

        private void LoadCards()
        {
            foreach (Transform slot in _cardsPanel)
            {
                if (slot.transform.childCount > 0)
                {
                    var card = slot.transform.GetChild(0);
                    if (card != null)
                    {
                        card.TryGetComponent<Card>(out var cardComp);
                        if (_currentTask.value._operatives.Contains(cardComp.ThisOperative) == false)
                        {
                            _currentTask.value._operatives.Add(cardComp.ThisOperative);
                        }
                    }
                }
            }
        }

        private void ReturnCards()
        {
            for (int i = 0; i < _endedTask.value._operatives.Count; i++)
            {
                var slot = Instantiate(_slotPrefab, _cardsStack);
                var card = Instantiate(_cardPrefab, slot.transform);
                card.GetComponent<Card>().ThisOperative = _endedTask.value._operatives[i];
            }
        }
    }
}
