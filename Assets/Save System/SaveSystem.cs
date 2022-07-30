using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Player;
using UnityEngine;

namespace Proiect.System.SaveSystem
{
    public static class SaveSystem
    {
        public static void SavePlayer(PlayerMovement playerMovement)
        {
            string path = Application.persistentDataPath + "/_player.psv";
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                PlayerData playerData = new PlayerData(playerMovement);
                formatter.Serialize(fs, playerData);
                fs.Close();
            }
        }

        public static PlayerData LoadPlayer()
        {
            PlayerData playerData;
            string path = Application.persistentDataPath + "/_player.psv";
            if (File.Exists(path))
            {
                var formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    playerData = formatter.Deserialize(fs) as PlayerData;
                    fs.Close();
                    return playerData;
                }
            }
            else
            {
                Debug.Log("[SaveSystem] Save file does not exist!");
                return null;
            }
        }
    }
}

