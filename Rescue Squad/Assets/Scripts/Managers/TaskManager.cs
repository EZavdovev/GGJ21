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
        private ScriptableTaskValue _currentTask;

        [SerializeField]
        private Transform _cardsPanel;


        private void OnEnable()
        {
            _setCardEventListener.OnEventHappened += LoadCards;
        }

        private void OnDisable()
        {
            _setCardEventListener.OnEventHappened -= LoadCards;
        }

        private void LoadCards()
        {
            foreach (Transform slot in _cardsPanel)
            {
                if (slot.transform.childCount > 0)
                {
                    var card = slot.transform.GetChild(0);
                    Debug.Log(card.GetComponent<Card>().ThisOperative.name);
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
    }
}
