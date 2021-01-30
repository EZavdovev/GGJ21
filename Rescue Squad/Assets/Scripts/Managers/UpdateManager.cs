using UnityEngine;
using Events;

namespace Game.Managers
{

    public class UpdateManager : MonoBehaviour
    {

        [SerializeField]
        private ScriptableEvent _updateEvent;

        [SerializeField]
        private ScriptableEvent _fixedUpdateEvent;

        private void Update()
        {
            _updateEvent.Dispatch();
        }

        private void FixedUpdate()
        {
            _fixedUpdateEvent.Dispatch();
        }
    }
}