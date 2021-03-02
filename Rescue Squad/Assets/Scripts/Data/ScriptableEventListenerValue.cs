using UnityEngine;
using Events;


namespace Game.Data
{

    [CreateAssetMenu(menuName = "GameData/Event Listener Value", fileName = ("New Event Listener Value"))]
    public class ScriptableEventListenerValue : ScriptableObject
    {

        public EventListener value;
    }
}
