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
        private GameObject _cardsMenu;

        [SerializeField]
        private GameObject _slotPrefab;

        private void OnEnable()
        {
            SpawnCardsSlots();
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            DeletCardsSlots();
            Time.timeScale = 1f;
        }

        private void SpawnCardsSlots()
        {
            for (int i = 0; i < _task.value.operativesSlots; i++)
            {
                Instantiate(_slotPrefab, _cardsMenu.transform);
            }
        }

        private void DeletCardsSlots()
        {
            for (int i = 0; i < _task.value.operativesSlots; i++)
            {
                Destroy(_cardsMenu.transform.GetChild(i).gameObject);
            }
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }

        public void SendBoyz()
        {
            Debug.Log("Boyz are sent");
            _startTaskDispatcher.Dispatch();
            gameObject.SetActive(false);
        }
    }
}
