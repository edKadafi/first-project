using System.Collections;
using System.Collections.Generic;
using Proiect.Player;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float[] rotation;
    public float health;

    public PlayerData(PlayerMovement playerMovement)
    {
        health = PlayerManager.Player.GetHp();
        position = new float[3];
        position[0] = playerMovement.transform.position.x;
        position[1] = playerMovement.transform.position.y;
        position[2] = playerMovement.transform.position.z;

        rotation = new float[4];
        rotation[0] = playerMovement.transform.rotation.x;
        rotation[1] = playerMovement.transform.rotation.y;
        rotation[2] = playerMovement.transform.rotation.z;
        rotation[3] = playerMovement.transform.rotation.w;
    }
}
