using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace UI 
{
    public class MenuScreen : MonoBehaviour 
    {
        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private Button _exitButton;

        private const int _gameplayScene = 1;
        private void Awake() {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnPlayButtonClick() {
                SceneManager.LoadScene(_gameplayScene);
        }

        private void OnExitButtonClick() {
            Application.Quit();
        }
    }
}
