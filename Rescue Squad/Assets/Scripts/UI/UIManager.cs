using UnityEngine;

namespace Game.UI
{

    public class UIManager : MonoBehaviour
    {

        public static UIManager instance;

        [SerializeField]
        private GameObject _gameScreen;

        [SerializeField]
        private GameObject _eventScreen;

        [SerializeField]
        private GameObject _menuScreen;

        [SerializeField]
        private GameObject _settingsScreen;



        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void EnableGameScreens()
        {
            _gameScreen.SetActive(true);
            _eventScreen.SetActive(false);
            _menuScreen.SetActive(false);
            _settingsScreen.SetActive(false);
        }
    }
}

