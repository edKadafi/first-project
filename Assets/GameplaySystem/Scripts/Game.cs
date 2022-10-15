using System;
using System.Collections;
using System.Collections.Generic;
using Proiect.Game.States;
using Proiect.Player;
using UnityEngine;

namespace Proiect.GamePlay
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameObject game;
        [SerializeField] private GameObject environment;
        [SerializeField] private GameObject player;

        private void Start()
        {
            // if (GameStateManager.CurrentState != null)
            // {
            //     Debug.Log("[GameStateManager] Game State = " + GameStateManager.CurrentState.StateName);
            // }
            //
            // GameStateManager.TransitionTo("GamePlay");
            // if (GameStateManager.CurrentState != null)
            // {
            //     Debug.Log("[GameStateManager] Game State = " + GameStateManager.CurrentState.StateName);
            // }

            Instantiate(environment);
            environment.tag = "Environment";
            Instantiate(game);
            game.tag = "Game";
            InstantiatePlayer();
            GameStateManager.TransitionTo("GamePlay");
        }

        public void InstantiatePlayer()
        {
            var _instancePlayer = Instantiate(player);
            PlayerManager.Init(_instancePlayer.GetComponent<MainPlayer>());
            player.tag = "Player";
            UI.UI.System.EnableHealthBar();
        }
    }
}