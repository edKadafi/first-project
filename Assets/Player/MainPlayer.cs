using Proiect.System.SaveSystem;
using UnityEngine;

namespace Proiect.Player
{
    public class MainPlayer : MonoBehaviour
    {
        public GameObject _player;
        private PlayerData _playerData;
        private float healthPoints = 100;

        private void Awake()
        {
            
        }

        private void Start()
        {
            _player = gameObject;
            PlayerManager.SetPlayer(_player.GetComponent<MainPlayer>());
            Debug.Log("[MainPlayer] Start " + _player);
        }
        
        public void LoadPlayer()
        {
            _playerData = SaveSystem.LoadPlayer();
            Debug.Log("Pos: " + _playerData.position[0] + "-" + _playerData.position[1] + "-" +
                      _playerData.position[2]);
            if (_playerData != null)
            {
                ApplyPlayerData();
                Debug.Log(_player);
            }
            else
            {
                Debug.Log("[MainPlayer] No PlayerData available! Using default.");
                return;
            }
        }

        private void ApplyPlayerData()
        {
            Debug.Log("[MainPlayer] Applying player data.");
            Vector3 tempPosition = new Vector3(_playerData.position[0], _playerData.position[1], _playerData.position[2]);
            Quaternion tempRotation = new Quaternion(_playerData.rotation[0], _playerData.rotation[1], _playerData.rotation[2], _playerData.rotation[3]);
            _player.transform.SetPositionAndRotation(tempPosition, tempRotation);
            healthPoints = _playerData.health;
        }

        public void AddHp(float add)
        {
            if (healthPoints == 100f)
            {
                return;
            }
            else
            {
                if (healthPoints + add > 100)
                {
                    var aux = 100 - (healthPoints + add);
                    healthPoints += add + aux;

                }
                else
                {
                    healthPoints += add;
                }
            }
        }

        public void LowerHp(float lower)
        {
            if (healthPoints - lower < 0)
            {
                var aux = healthPoints - lower;
                healthPoints -= lower + aux;
            }
            else
            {
                healthPoints -= lower;
            }
        }
        public float GetHp()
        {
            return healthPoints;
        }

        public float[] GetColor()
        {
            var color = new float[4];
            color[0] = _player.GetComponentInChildren<SkinnedMeshRenderer>().material.color.r;
            color[1] = _player.GetComponentInChildren<SkinnedMeshRenderer>().material.color.g;
            color[2] = _player.GetComponentInChildren<SkinnedMeshRenderer>().material.color.b;
            color[3] = _player.GetComponentInChildren<SkinnedMeshRenderer>().material.color.a;

            return color;
            
        }
        
        
    }
}

