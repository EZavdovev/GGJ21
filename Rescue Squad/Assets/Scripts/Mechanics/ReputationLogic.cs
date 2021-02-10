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


        private const int CHANGER_SCORE = 10;
        private const int FAILED_SCORE = 20;

        private void Awake() {
            _SuccessEventListener.OnEventHappened += Success;
            _failedEventListener.OnEventHappened += Failed;
        }

        private void Success() {
            _reputation.value += CHANGER_SCORE;
        }

        private void Failed() {
            _reputation.value -= CHANGER_SCORE;
            if(_reputation.value <= FAILED_SCORE) {
                _endGameDispatcher.Dispatch();
            }
        }
    }

}
