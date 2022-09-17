using Proiect.Player;
using Proiect.Player.DebugUtils;
using Proiect.System.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proiect.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        
        private DebugUtils _debugUtils;
        private PlayerMovement _playerMovement;

        public void Back()
        {
            _pauseMenu.gameObject.SetActive(false);
            Debug.Log("[PauseMenu] State: "+_pauseMenu.activeSelf);
        }

        public void SaveGame()
        {
            SaveSystem.SavePlayer(PlayerManager.Player.GetComponent<PlayerMovement>());
            SaveSystem.SaveEnvironment(_debugUtils.objects);
        }

        public void LoadGame()
        {
            NewGame();
            PlayerManager.Player.LoadPlayer();
            FindObjectOfType<Environment>().LoadEnvironment();
            
        }
        public void NewGame()
        {
            if (_debugUtils != null)
            {
                _debugUtils.BeginNewGame();
                _pauseMenu.gameObject.SetActive(false);
            }
        }
    
        // Start is called before the first frame update
        void Start()
        {
            _debugUtils = FindObjectOfType<DebugUtils>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }
    }
}

