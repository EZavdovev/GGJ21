using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Game.Testing
{

    public class TriggerEvent : MonoBehaviour
    {
        [SerializeField]
        private EventListener _updateListener;

        [SerializeField]
        private EventDispatcher _pointOfInterestDispatcher;

        private void OnEnable()
        {
            _updateListener.OnEventHappened += TriggerEventMethod;
        }

        private void OnDisable()
        {
            _updateListener.OnEventHappened -= TriggerEventMethod;
        }

        private void TriggerEventMethod()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _pointOfInterestDispatcher.Dispatch();
                Debug.Log("Dispatching");
            }
        } 
    }
}

