﻿using UnityEngine.UI;
using UnityEngine;
using Game.Data;

namespace Game.UI
{

    public class PointOfInterestInterface : MonoBehaviour
    {

        [SerializeField]
        private ScriptableTaskValue _task;

        [SerializeField]
        private ScriptableGameObjectValue _eventScreen;

        [SerializeField]
        private Text _description;

        [SerializeField]
        private Image _taskImage;


        private void OnMouseDown()
        {
            EnableScreen();
            InitializeEventScreen();
        }

        private void EnableScreen()
        {
            _eventScreen.value.SetActive(true);
        }

        private void InitializeEventScreen()
        {
            _description = _eventScreen.value.transform.GetChild(1).GetComponent<Text>();
            _taskImage = _eventScreen.value.transform.GetChild(2).GetComponent<Image>();
            _description.text = _task.value.description;
            _taskImage.sprite = _task.value.logo;
        }
    }
}