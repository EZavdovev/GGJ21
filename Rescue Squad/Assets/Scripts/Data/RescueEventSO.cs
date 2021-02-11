using System.Collections.Generic;
using UnityEngine;

namespace Game.Data
{

    [CreateAssetMenu(fileName = "New Rescue Event", menuName = "GameData/RescuePoint")]
    public class RescueEventSO : ScriptableObject
    {

        public string taskName = "";

        public Sprite logo;
        public Sprite successImage;
        public Sprite failImage;

        [Space(10)]
        [TextArea(4, 8)]
        public string description = "";
        [TextArea(4, 8)]
        public string successText = "";
        [TextArea(4, 8)]
        public string failText = "";

        [Space(10)]
        public int searchingRadius = 0;
        public int operativesSlots = 0;
        public int timeToReact = 10;

        [Space(10)]
        public List<OperativeSO> _operatives;

        [Space(10)]
        public bool isInteractbale = true;
        public bool isFake = true;

        //На данный момент ограничения для координат следующие: по иксу от -12 до 12, по игреку от -9 до 9
        [Space(10)]
        public Vector2 coordinates = Vector2.zero;

        public void ClearSO()
        {
            _operatives.Clear();
        }

        public float SpeedModifier()
        {
            var sum = 0f;
            var result = 0f;
            var modifier = 50f;
            for (int i = 0; i < _operatives.Count; i++)
            {
                sum += _operatives[i].expirience;
            }
            result = sum / modifier;
            return result;
        }
    }
}

