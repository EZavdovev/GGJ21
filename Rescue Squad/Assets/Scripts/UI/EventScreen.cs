using UnityEngine;
using Game.Data;
using Events;
using UnityEngine.UI;

namespace Game.UI
{

    public class EventScreen : MonoBehaviour
    {

        [SerializeField]
        private ScriptableTaskValue _task;

        [SerializeField]
        private ScriptableEventListenerValue _startTaskEventValue;

        [SerializeField]
        private EventDispatcher _startTaskDispatcher;

        [SerializeField]
        private Transform _cardsMenu;

        [SerializeField]
        private GameObject _slotPrefab;

        [SerializeField]
        private GameObject _cardPrefab;

        [SerializeField]
        private Text _description;


        [SerializeField]
        private Image _taskImage;

        private void OnEnable()
        {
            SpawnCardsSlots();
            InitializeEventScreen();
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
            DeleteCardsSlots();
        }

        private void InitializeEventScreen()
        {
            _description.text = _task.value.description;
            _taskImage.sprite = _task.value.logo;
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
            _startTaskEventValue.value.enabled = false;
            _startTaskEventValue.value = null;
            gameObject.SetActive(false);
        }

        public void SendBoyz()
        {
            _startTaskDispatcher.Dispatch();
            gameObject.SetActive(false);
        }
    }
}
