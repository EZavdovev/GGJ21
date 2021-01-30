﻿using UnityEngine;

namespace Game.Data
{

    [CreateAssetMenu(fileName = "New Rescue Event", menuName = "GameData/RescuePoint")]
    public class RescueEventSO : ScriptableObject
    {

        public string taskName = "";

        public Texture2D logo;
        public Texture2D successImage;
        public Texture2D failImage;

        [Space(10)]
        [TextArea(4, 8)]
        public string description = "";
        public string successText = "";
        public string failText = "";

        [Space(10)]
        public int searchingRadius = 0;
        public int operativesSlots = 0;
        public int timeToReact = 10;

        [Space(10)]
        public bool isInteractbale = true;
        public bool isFake = true;

        //На данный момент ограничения для координат следующие: по иксу от -12 до 12, по игреку от -9 до 9
        [Space(10)]
        public Vector2 coordinates = Vector2.zero;

    }
}

