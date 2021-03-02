using UnityEngine.UI;
using UnityEngine;
using Game.Data;
using Events;
using System.Collections;

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
            //_thisTask = _task.value;
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
            _startTaskEventValue.value = _startTaskEventListener;
            _task.value = _thisTask;
            EnableScreen();
            Time.timeScale = 0f;
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
                    transform.localScale -= _scaleChanger * _thisTask.SpeedModifier();
                }
                if (transform.localScale.x <= 5f)
                {
                    transform.localScale = new Vector3(5f, 5f, 0f);
                    Debug.Log("Make a report");
                    //ReturnCards(); Вот тут сделать событие о завершении задания
                    _thisTask.ClearSO();
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

        private IEnumerator Thinning()
        {
            if(_canThick == true)
            {
                Debug.Log("Coroutine started");
                yield return new WaitForSeconds(3f);
                Debug.Log("Coroutine ended");
            }
        }
    }
}
