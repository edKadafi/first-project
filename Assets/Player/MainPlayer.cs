using System;
using System.Collections;
using System.Collections.Generic;
using Proiect.System.SaveSystem;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class MainPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private PlayerData _playerData;
    private void Start()
    {
        LoadPlayer();
    }

    private void LoadPlayer()
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
}
