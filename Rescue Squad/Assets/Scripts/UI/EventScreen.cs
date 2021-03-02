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
        private Transform _cardsStack;

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

        private void ReturnCards()
        {
            for (int i = 0; i < _task.value._operatives.Count; i++)
            {
                var slot = Instantiate(_slotPrefab, _cardsStack);
                var card = Instantiate(_cardPrefab, slot.transform);
                card.GetComponent<Card>().ThisOperative = _task.value._operatives[i];
                Debug.Log(i);
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
