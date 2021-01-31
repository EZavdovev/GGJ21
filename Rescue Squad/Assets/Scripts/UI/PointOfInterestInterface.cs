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
        private Vector3 _scaleChanger = Vector3.zero;


        private void OnEnable()
        {
            _thisTask = _task.value;
            _updateEventListener.OnEventHappened += CounterMethod;
            _updateEventListener.OnEventHappened += StartThicking;
            _startTaskEventListener.OnEventHappened += StartThicking;
        }

        private void OnDisable()
        {
            _updateEventListener.OnEventHappened -= CounterMethod;
            _updateEventListener.OnEventHappened -= StartThicking;
            _startTaskEventListener.OnEventHappened -= StartThicking;
        }


        private void OnMouseDown()
        {
            EnableScreen();
            _task.value = _thisTask;
            InitializeEventScreen();
        }

        private void EnableScreen()
        {
            _eventScreen.value.SetActive(true);
        }

        private void InitializeEventScreen()
        {
            _description = _eventScreen.value.transform.GetChild(1).GetComponent<Text>();
            _taskImage = _eventScreen.value.transform.GetChild(2).GetComponent<Image>();
            _description.text = _task.value.description;
            _taskImage.sprite = _task.value.logo;
        }

        private void StartThicking()
        {
            Debug.Log("Task Started");
            _mustCount = false;
            if(_mustCount == false)
            {
                transform.localScale -= _scaleChanger;
            }
            if(transform.localScale.x <= 5f)
            {
                transform.localScale = new Vector3(5f, 5f, 0f);
                Debug.Log("Make a report");
                Destroy(gameObject);
                
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
