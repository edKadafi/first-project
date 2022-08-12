using System;
using System.Collections;
using System.Collections.Generic;
using Proiect.Player;
using UnityEngine;

namespace Proiect.GamePlay
{
    public class GamePlay : MonoBehaviour
    {
        [SerializeField] private GameObject game;
        [SerializeField] private GameObject environment;
        [SerializeField] private GameObject player;
        [SerializeField] private UI.UI ui;

        private void Start()
        {
            GameStateManager.Initialize();
            if (GameStateManager.GetCurrentState() != null)
            {
                Debug.Log("[GameStateManager] Game State = "+ GameStateManager.GetCurrentState().GetName());
            }
            GameStateManager.InitializeState(2);
            if (GameStateManager.GetCurrentState() != null)
            {
                Debug.Log("[GameStateManager] Game State = "+ GameStateManager.GetCurrentState().GetName());
            }
            
            Instantiate(environment);
            environment.tag = "Environment";
            Instantiate(game);
            game.tag = "Game";
            Instantiate(player);
            PlayerManager.Init(player.GetComponent<MainPlayer>());
            player.tag = "Player";
            Instantiate(ui);
            DontDestroyOnLoad(ui);
        }
    }
}

