using UnityEngine;

using System.Collections.Generic;
using Game.Data;

namespace Game.Managers
{
    public class TaskManager : MonoBehaviour
    {

        [SerializeField]
        private List<RescueEventSO> _tasks;

        [SerializeField]
        private GameObject _marker;

        private float timeLeft;
        private Vector2 _coordinates;

        private void Awake()
        {
            SpawnTaskMarkerOnMap(_tasks[0]);
        }


        private RescueEventSO GetRandomTask()
        {
            var ramdomTaskItdex = Random.Range(0, _tasks.Count - 1);
            var task = _tasks[ramdomTaskItdex];

            return task;
        }

        private void SpawnTaskMarkerOnMap(RescueEventSO so)
        {
            //x(-12;12) y(-9;9)
            var spawn = so.coordinates;
            var spawnTask = Instantiate(_marker, spawn, Quaternion.identity);
           
        }
    }
}
