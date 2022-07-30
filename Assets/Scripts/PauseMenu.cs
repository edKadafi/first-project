using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proiect.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;

        [SerializeField] private GameObject _backButton;
        private Game _game;

        void Back()
        {
            _pauseMenu.gameObject.SetActive(false);
        }

        public void NewGame()
        {
            if (_game != null)
            {
                _game.BeginNewGame();
                _pauseMenu.gameObject.SetActive(false);
            }
        }
    
        // Start is called before the first frame update
        void Start()
        {
            _game = FindObjectOfType<Game>();
        }
    }
}

