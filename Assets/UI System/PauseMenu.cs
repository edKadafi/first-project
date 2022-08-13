using Proiect.Player;
using Proiect.System.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proiect.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        
        private Game _game;
        private PlayerMovement _playerMovement;

        public void Back()
        {
            _pauseMenu.gameObject.SetActive(false);
            Debug.Log("[PauseMenu] State: "+_pauseMenu.activeSelf);
        }

        public void SaveGame()
        {
            SaveSystem.SavePlayer(PlayerManager.Player.GetComponent<PlayerMovement>());
            SaveSystem.SaveEnvironment(_game.objects);
        }

        public void LoadGame()
        {
            NewGame();
            PlayerManager.Player.LoadPlayer();
            FindObjectOfType<Environment>().LoadEnvironment();
            
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

