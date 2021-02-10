using UnityEngine;
using Events;


namespace Game.Data
{

    [CreateAssetMenu(menuName = "GameData/EventValue", fileName = ("New Event Value"))]
    public class ScriptableDispatcherValue : ScriptableObject
    {

        public EventDispatcher value;
    }
}
