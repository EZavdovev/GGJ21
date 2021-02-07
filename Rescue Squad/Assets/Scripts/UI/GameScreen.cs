using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Events;

namespace Game.UI
{

    public class GameScreen : MonoBehaviour
    {

        [SerializeField]
        private List<GameObject> _cardsRemaining;

        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private Camera _mainCam;

    }
}
