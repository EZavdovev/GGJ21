using UnityEngine.UI;
using UnityEngine;
using Game.Data;

namespace Game.UI
{

    public class PointOfInterestInterface : MonoBehaviour
    {

        [SerializeField]
        private ScriptableTaskValue _task;

        [SerializeField]
        private GameObject _eventScreen;

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
            Debug.Log("Enabling");
            _eventScreen.SetActive(true);
            Debug.Log("Enabled");
        }

        private void InitializeEventScreen()
        {
            if(_eventScreen.activeInHierarchy == true)
            {
                _description = _eventScreen.transform.GetChild(1).GetComponent<Text>();
                _taskImage = _eventScreen.transform.GetChild(2).GetComponent<Image>();
                _description.text = _task.value.description;
                _taskImage.sprite = _task.value.logo;

            }
        }
    }
}
