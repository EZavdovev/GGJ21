using UnityEngine.UI;
using UnityEngine;
using Game.Data;
using Events;

namespace Game.UI
{

    public class PointOfInterestInterface : MonoBehaviour
    {

        [SerializeField]
        private float _timeToReact = 10f;

        [SerializeField]
        private ScriptableTaskValue _task;

        [SerializeField]
        private ScriptableGameObjectValue _eventScreen;

        [SerializeField]
        private ScriptableGameObjectValue _cardsStack;

        [SerializeField]
        private Transform _taskPanel;

        [SerializeField]
        private RescueEventSO _thisTask;

        [SerializeField]
        private Text _description;

        [SerializeField]
        private Image _taskImage;

        [SerializeField]
        private Text _timeToReactText;

        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private EventListener _startTaskEventListener;

        [SerializeField]
        private bool _mustCount = true;

        [SerializeField]
        private bool _canThick = false;

        [SerializeField]
        private GameObject _cardPrefab;

        [SerializeField]
        private GameObject _slotPrefab;

        [SerializeField]
        private Vector3 _scaleChanger = Vector3.zero;


        private void OnEnable()
        {
            _thisTask = _task.value;
            _updateEventListener.OnEventHappened += CounterMethod;
            _updateEventListener.OnEventHappened += StartThicking;
            _startTaskEventListener.OnEventHappened += CanThick;
        }

        private void OnDisable()
        {
            _updateEventListener.OnEventHappened -= CounterMethod;
            _updateEventListener.OnEventHappened -= StartThicking;
            _startTaskEventListener.OnEventHappened -= CanThick;
            _startTaskEventListener.enabled = false;
            Time.timeScale = 1f;
        }


        private void OnMouseDown()
        {
            _startTaskEventListener.enabled = true;
            EnableScreen();
            _task.value = _thisTask;
            InitializeEventScreen();
            Time.timeScale = 0f;
        }

        private void EnableScreen()
        {
            _eventScreen.value.SetActive(true);
            _taskPanel = _eventScreen.value.transform.GetChild(0);
        }

        private void InitializeEventScreen()
        {
            _description = _taskPanel.GetChild(1).GetComponent<Text>();
            _taskImage = _taskPanel.GetChild(2).GetComponent<Image>();
            _description.text = _task.value.description;
            _taskImage.sprite = _task.value.logo;
        }

        private void CanThick()
        {
            _canThick = true;
        }

        private void StartThicking()
        {
            if(_canThick == true)
            {
                _mustCount = false;
                if (_mustCount == false)
                {
                    transform.localScale -= _scaleChanger * _thisTask.SpeedModifier();
                }
                if (transform.localScale.x <= 5f)
                {
                    transform.localScale = new Vector3(5f, 5f, 0f);
                    Debug.Log("Make a report");
                    ReturnCards();
                    _thisTask.ClearSO();
                    Destroy(gameObject);
                }
            }
        }

        private void ReturnCards()
        {
            for (int i = 0; i < _thisTask._operatives.Count; i++)
            {
                var slot = Instantiate(_slotPrefab, _cardsStack.value.transform);
                var card = Instantiate(_cardPrefab, slot.transform);
                card.GetComponent<Card>().ThisOperative = _thisTask._operatives[i];
                Debug.Log(i);
            }
        }

        private void CounterMethod()
        {
            if(_mustCount == true)
            {
                _timeToReactText.text = Mathf.RoundToInt(_timeToReact).ToString();
                _timeToReact -= Time.deltaTime;
                if (_timeToReact <= 0f)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                _timeToReactText.enabled = false;
            }
        }
    }
}
