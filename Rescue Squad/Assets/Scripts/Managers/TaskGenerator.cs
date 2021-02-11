using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Events;

namespace Game.Managers
{
    public class TaskGenerator : MonoBehaviour
    {

        [SerializeField]
        private List<RescueEventSO> _tasks;

        [SerializeField]
        private ScriptableTaskValue _currentTask;

        [SerializeField]
        private GameObject _marker;

        [SerializeField]
        private EventListener _taskCreated;

        private void OnEnable()
        {
            _taskCreated.OnEventHappened += SpawnTaskMarkerOnMap;
        }

        private void OnDisable()
        {
            _taskCreated.OnEventHappened -= SpawnTaskMarkerOnMap;
        }

        private RescueEventSO GetRandomTask()
        {
            var ramdomTaskItdex = Random.Range(0, _tasks.Count);
            var task = _tasks[ramdomTaskItdex];

            return task;
        }

        private void SpawnTaskMarkerOnMap()
        {
            //x(-12;12) y(-9;9)
            if(_tasks.Count != 0)
            {
                _currentTask.value = GetRandomTask();
                var spawn = _currentTask.value.coordinates;
                var spawnTask = Instantiate(_marker, spawn, Quaternion.identity);
                spawnTask.transform.localScale = new Vector3(_currentTask.value.searchingRadius, _currentTask.value.searchingRadius, 0f);
                _tasks.Remove(_currentTask.value);
            }
            else 
            { 
                Debug.Log("No tasks"); 
            }
        }
    }
}
