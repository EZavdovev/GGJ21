using UnityEngine;

namespace Game.Data
{

    [CreateAssetMenu(fileName = "New Operative", menuName = "GameData/Operative")]
    public class OperativeSO : ScriptableObject
    {
        public Texture2D photo;
        public string operativeName = "";
        public int rank = 0;
        public int expirience = 0;
    }
}

