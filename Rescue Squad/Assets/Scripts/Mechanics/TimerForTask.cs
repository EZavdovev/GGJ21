using UnityEngine;
using System.Collections;
using Events;


namespace Game.Mechanics
{

    public class TimerForTask : MonoBehaviour
    {

        [SerializeField]
        private EventListener _updateListener;

        [SerializeField]
        private EventDispatcher _taskEventDispatcher;

        [SerializeField]
        private float _maxSeconds = 16f;

        [SerializeField]
        private float _minSeconds = 5f;

        [SerializeField]
        private float _duration = 0f;

        [SerializeField]
        private bool _canDispatch = false;

        private void OnEnable()
        {
            _updateListener.OnEventHappened += Checker;
        }

        private void OnDisable()
        {
            _updateListener.OnEventHappened -= Checker;
        }

        private void Start()
        {
            _duration = RandomizeTimer();
        }

        private float RandomizeTimer()
        {
            var rand = Random.Range(_minSeconds, _maxSeconds);
            return rand;
        }

        private void Checker()
        {
            if (_canDispatch == true)
            {
                _taskEventDispatcher.Dispatch();
                _canDispatch = false;
            }
            Tick();
        }

        private void Tick()
        {
            _canDispatch = false;
            _duration -= Time.deltaTime;
            if(_duration <= 0f)
            {
                _duration = RandomizeTimer();
                _canDispatch = true;
            }
        }
    }
}

