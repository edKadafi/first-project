using System;
using System.Collections;
using System.Collections.Generic;
using Proiect.System.SaveSystem;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Proiect.Player
{
    public class MainPlayer : MonoBehaviour
    {
        public Transform _player;
        private PlayerData _playerData;
        private float healthPoints = 100;
    
        private void Start()
        {
        
        }

        public void Init()
        {
            healthPoints = 100;
        }

        public void LoadPlayer()
        {
            _playerData = SaveSystem.LoadPlayer();
            if (_playerData != null)
            {
                ApplyPlayerData();
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
            _player.SetPositionAndRotation(tempPosition, tempRotation);
        }

        public void AddHP(float add)
        {
            if (healthPoints == 100)
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
            Debug.Log("[MainPlayer] New health:"+healthPoints);
        }

        public void LowerHP(float lower)
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
            Debug.Log("[MainPlayer] New health:"+healthPoints);
        }

        public float GetHp()
        {
            return healthPoints;
        }
        
    }
}

