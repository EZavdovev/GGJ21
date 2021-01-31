using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
namespace Game.Mechanics 
{
    public class ReputationLogic : MonoBehaviour {
        [SerializeField]
        private EventListener _SuccessEventListener;
        [SerializeField]
        private EventListener _failedEventListener;
        [SerializeField]
        private EventDispatcher _endGameDispatcher;
        [SerializeField]
        private ScriptableFloatValue _reputation;


        private const int _changerScore = 10;
        private const int _failedScore = 20;
        private void Awake() {
            _SuccessEventListener.OnEventHappened += Success;
            _failedEventListener.OnEventHappened += Failed;
        }

        private void Success() {
            _reputation.value += _changerScore;
        }

        private void Failed() {
            _reputation.value -= _changerScore;
            if(_reputation.value <= _failedScore) {
                _endGameDispatcher.Dispatch();
            }
        }
    }

}
