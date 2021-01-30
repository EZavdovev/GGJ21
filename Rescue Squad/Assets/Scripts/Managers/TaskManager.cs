using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

namespace Game.Managers
{
    public class TaskManager : MonoBehaviour
    {

        [SerializeField]
        private List<ScriptableObject> _tasks;

        [SerializeField]
        private GameObject _marker;

        private float timeLeft;

        private void Awake()
        {
        }

        private void Update()
        {
            SpawnTaskMarkerOnMap();
        }
        private ScriptableObject GetRandomTask()
        {
            var ramdomTaskItdex = Random.Range(0, _tasks.Count - 1);
            var task = _tasks[ramdomTaskItdex];
            return task;
        }

        private void SpawnTaskMarkerOnMap()
        {
            var spawn = new Vector2(50, 50);
            var enemyCar = Instantiate(_marker, spawn, Quaternion.identity);
        }
    }
}
