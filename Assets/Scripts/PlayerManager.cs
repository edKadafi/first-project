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
        public static HealthBar healthBar;
        
    
        public static void Init(MainPlayer p)
        {
            Player = p;
            Player.Init();
            Debug.Log("[PlayerManager] HP initialized");
            
        }

        public static void DamagePlayer(float dmg)
        {
            Player.LowerHP(dmg);
        }

        public static void HealPlayer(float heal)
        {
            Player.AddHP(heal);
        }
    }    
}

