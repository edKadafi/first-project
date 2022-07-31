using System;
using System.Collections;
using System.Collections.Generic;
using Proiect.Player;
using Proiect.System.SaveSystem;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private Game _game;
    private Transform _environment;
    private EnvironmentData _environmentData;

    private void Start()
    {
        _game = FindObjectOfType<Game>();
        _environment = GameObject.FindGameObjectWithTag("Environment").transform;
    }

    public void LoadEnvironment()
    {
        _environmentData = SaveSystem.LoadEnvironment();
        if (_environmentData != null)
        {
            ApplyEnvironmentData();
        }
        else
        {
            Debug.Log("[MainPlayer] No EnvironmentData available! Using default.");
            return;
        }
    }

    private void ApplyEnvironmentData()
    {
        Debug.Log("[Environment] Applying environment data.");
        
        for (int i = 0; i < _environmentData.positions.Length; i++)
        {
            var aux = new GameObject();
            Vector3 tempPosition = new Vector3(_environmentData.positions[i][0], _environmentData.positions[i][1], _environmentData.positions[i][2]);
            Quaternion tempRotation = new Quaternion(_environmentData.rotations[i][0], _environmentData.rotations[i][1], _environmentData.rotations[i][2], _environmentData.rotations[i][3]);
            aux.transform.SetPositionAndRotation(tempPosition, tempRotation);
            _game.objects.Add(aux.transform);
            Destroy(aux);
        }
        
        _game.CreateList(_game.objects);
    }
}
