using UnityEngine;

namespace Game.Data
{

    [CreateAssetMenu(fileName = "New GameObjectValue", menuName = "GameData/GO")]
    public class ScriptableGameObjectValue : ScriptableObject
    {

        public GameObject value;
    }
}
