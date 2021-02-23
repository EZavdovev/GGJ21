using UnityEngine;
using Game.Data;
using Events;

namespace Game.UI
{

    public class EventScreen : MonoBehaviour
    {

        [SerializeField]
        private ScriptableTaskValue _task;

        [SerializeField]
        private EventDispatcher _startTaskDispatcher;

        [SerializeField]
        private Transform _cardsMenu;

        [SerializeField]
        private GameObject _slotPrefab;

        private void OnEnable()
        {
            SpawnCardsSlots();
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
            DeleteCardsSlots();
        }

        private void SpawnCardsSlots()
        {
            for (int i = 0; i < _task.value.operativesSlots; i++)
            {
                Instantiate(_slotPrefab, _cardsMenu.transform);
            }
        }

        private void DeleteCardsSlots()
        {
            foreach (Transform slot in _cardsMenu)
            {
                Destroy(slot.gameObject);
            }
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }

        public void SendBoyz()
        {
            _startTaskDispatcher.Dispatch();
            gameObject.SetActive(false);
        }
    }
}
