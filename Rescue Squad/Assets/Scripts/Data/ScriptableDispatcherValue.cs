using UnityEngine;
using Events;


namespace Game.Data
{

    [CreateAssetMenu(menuName = "GameData/Event Dispatcher Value", fileName = ("New Event Value"))]
    public class ScriptableDispatcherValue : ScriptableObject
    {

        public EventDispatcher value;
    }
}
