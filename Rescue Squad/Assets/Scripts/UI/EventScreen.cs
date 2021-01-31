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
        private GameObject _cardPrefab;

        private void OnEnable()
        {
            SpawnCards();
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }

        private void SpawnCards()
        {
            for (int i = 0; i < _task.value.operativesSlots; i++)
            {
                Instantiate(_cardPrefab, _cardsMenu.transform);
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
