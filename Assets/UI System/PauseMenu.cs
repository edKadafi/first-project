using System.Collections;
using System.Collections.Generic;
using Player;
using Proiect.System.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proiect.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;

        [SerializeField] private GameObject _backButton;
        private Game _game;
        private PlayerMovement _playerMovement;

        void Back()
        {
            _pauseMenu.gameObject.SetActive(false);
        }

        public void SaveGame()
        {
            SaveSystem.SavePlayer(_playerMovement);
        }

        public void LoadGame()
        {
            PlayerData playerData = SaveSystem.LoadPlayer();
            
            
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
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }
    }
}

