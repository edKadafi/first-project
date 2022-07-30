using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject player;

    private void Start()
    {
        Instantiate(environment);
        environment.tag = "Environment";
        Instantiate(game);
        game.tag = "Game";
        Instantiate(player);
        player.tag = "Player";
    }
}
