using System.Collections;
using System.Collections.Generic;
using System.IO;
using Proiect.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Proiect.Player
{
    public static class PlayerManager
    {
        public static MainPlayer Player{ get; private set; }

        public static void Init(MainPlayer p)
        {
            Player = p;
            Debug.Log("[PlayerManager] HP initialized");
            Debug.Log(Player.gameObject);

        }

        public static void DamagePlayer(float dmg)
        {
            Player.LowerHp(dmg);
            Debug.Log("[PlayerManager] Player is "+Player);
            Debug.Log(Player.GetHp() + " " + Player.gameObject);
        }

        public static void HealPlayer(float heal)
        {
            Player.AddHp(heal);
        }
        
        public static void SetPlayer(MainPlayer player)
        {
            Player = player;
        }
    }    
}

