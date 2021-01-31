using UnityEngine;

namespace Game.Data
{

    [CreateAssetMenu(fileName = "New Task", menuName = "GameData/Task")]
    public class ScriptableTaskValue : ScriptableObject
    {

        public RescueEventSO value;
    }
}
