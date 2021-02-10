using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Events;

namespace Game.Managers
{

    public class TaskManager : MonoBehaviour
    {

        [SerializeField]
        private EventListener _setCardEventListener;

        [SerializeField]
        private List<OperativeSO> _operativesToTask;

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
            foreach(Transform slot in _cardsPanel)
            {
                if(slot.transform.childCount > 0)
                {
                    var card = slot.transform.GetChild(0);
                    if (card != null)
                    {
                        card.TryGetComponent<Card>(out var cardComp);
                        if (_operativesToTask.Contains(cardComp.ThisOperative) == false)
                        {
                            Debug.Log(cardComp.ThisOperative.operativeName);
                            _operativesToTask.Add(cardComp.ThisOperative);
                        }
                    }
                }
            }
        }
    }
}
