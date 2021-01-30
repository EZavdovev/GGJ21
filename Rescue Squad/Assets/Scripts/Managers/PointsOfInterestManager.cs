/* Вот тут нужно продумать систему по передаче сюда разных заданий. Можно создать отдельный скрипт
 * с листом всех заданий и выбирать оттуда рандомные. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using Game.Data;

namespace Game.Managers
{

    public class PointsOfInterestManager : MonoBehaviour
    {

        [SerializeField]
        private EventListener _pointOfInterestEventListener;

        [SerializeField]
        private EventListener _updateListener;

        [SerializeField]
        private RescueEventSO _currentTask;

        private void OnEnable()
        {
            _updateListener.OnEventHappened += UpdateBehaviour;
            _pointOfInterestEventListener.OnEventHappened += ShowTaskInfo;
        }

        private void OnDisable()
        {
            _updateListener.OnEventHappened -= UpdateBehaviour;
            _pointOfInterestEventListener.OnEventHappened -= ShowTaskInfo;
        }

        private void UpdateBehaviour()
        {
            Debug.Log("Update on: " + this.name);
        }

        private void ShowTaskInfo()
        {
            Debug.Log("Task name: " + _currentTask.taskName);
            Debug.Log("Difficulty: " + _currentTask.searchingRadius);
            Debug.Log("Slots: " + _currentTask.operativesSlots);
        }
    }
}

