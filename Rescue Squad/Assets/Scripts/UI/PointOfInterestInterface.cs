using UnityEngine.UI;
using UnityEngine;
using Game.Data;
using Events;

namespace Game.UI
{

    public class PointOfInterestInterface : MonoBehaviour
    {

        public RescueEventSO _thisTask;

        [SerializeField]
        private float _timeToReact = 10f;

        [SerializeField]
        private ScriptableTaskValue _task;

        [SerializeField]
        private ScriptableTaskValue _endedTask;

        [SerializeField]
        private ScriptableEventListenerValue _startTaskEventValue;

        [SerializeField]
        private ScriptableGameObjectValue _eventScreen;

        [SerializeField]
        private ScriptableGameObjectValue _cardsStack;

        [SerializeField]
        private Text _timeToReactText;

        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private EventListener _startTaskEventListener;

        [SerializeField]
        private EventDispatcher _taskEndedDisptacher;

        [SerializeField]
        private bool _mustCount = true;

        [SerializeField]
        private bool _canThick = false;

        [SerializeField]
        private bool _dispatched = false;

        [SerializeField]
        private GameObject _cardPrefab;

        [SerializeField]
        private GameObject _slotPrefab;

        [SerializeField]
        private Vector3 _scaleChanger = Vector3.zero;


        private void OnEnable()
        {
            SubscribeToEvents();
        }

        private void OnDisable()
        {
            UnSubscribeToEvents();
            _startTaskEventListener.enabled = false;
        }

        private void SubscribeToEvents()
        {
            _updateEventListener.OnEventHappened += CounterMethod;
            _updateEventListener.OnEventHappened += StartThicking;
            _startTaskEventListener.OnEventHappened += CanThick;
        }
        private void UnSubscribeToEvents()
        {
            _updateEventListener.OnEventHappened -= CounterMethod;
            _updateEventListener.OnEventHappened -= StartThicking;
            _startTaskEventListener.OnEventHappened -= CanThick;
        }


        private void OnMouseDown()
        {
            _startTaskEventListener.enabled = true;
            _startTaskEventValue.value = _startTaskEventListener;
            _task.value = _thisTask;
            EnableScreen();
        }

        private void EnableScreen()
        {
            _eventScreen.value.SetActive(true);
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
                    Debug.Log($"Object {gameObject.name} started task");
                    transform.localScale -= _scaleChanger * _thisTask.SpeedModifier() * Time.deltaTime;
                    if(_endedTask.value != null)
                    {
                        Debug.Log("Task setted: " + _endedTask.value.taskName);
                    }
                }
                if (transform.localScale.x <= 5f)
                {
                    transform.localScale = new Vector3(5f, 5f, 0f);
                    _endedTask.value = _task.value;
                    if(_dispatched == false)
                    {
                        _taskEndedDisptacher.Dispatch();
                        _dispatched = true;
                        Debug.Log("Dispatched with task :" + _thisTask.taskName);
                    }
                    Debug.Log(_endedTask.value.taskName);
                    _thisTask.ClearSO();
                    UnSubscribeToEvents();
                    Destroy(gameObject);
                }
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
