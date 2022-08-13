using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Proiect.Player;
using UnityEngine;

namespace Proiect.System.SaveSystem
{
    public static class SaveSystem
    {
        private static string _playerPath = Application.persistentDataPath + "/_player.psv";
        private static string _envPath = Application.persistentDataPath + "/_environment.psv";
        

        #region Player

        public static void SavePlayer(PlayerMovement playerMovement)
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(_playerPath, FileMode.Create))
            {
                PlayerData playerData = new PlayerData(playerMovement);
                formatter.Serialize(fs, playerData);
                fs.Close();
            }
            Debug.Log("[SaveSystem] Player saved successfully.");
        }
        
        public static PlayerData LoadPlayer()
        {
            PlayerData playerData;
            if (File.Exists(_playerPath))
            {
                var formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(_playerPath, FileMode.Open))
                {
                    playerData = formatter.Deserialize(fs) as PlayerData;
                    fs.Close();
                    Debug.Log("Pos: " + playerData.position[0] + "-" + playerData.position[1] + "-" +
                              playerData.position[2]);
                    return playerData;
                }
            }
            else
            {
                Debug.Log("[SaveSystem] Player save file does not exist!");
                return null;
            }
        }

        #endregion

        #region Environment

        public static void SaveEnvironment(List<Transform> cubes)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(_envPath, FileMode.Create))
            {
                var environmentData = new EnvironmentData(cubes);
                formatter.Serialize(fs, environmentData);
                fs.Close();
            }
            Debug.Log("[SaveSystem] Environment saved successfully");
        }

        public static EnvironmentData LoadEnvironment()
        {
            EnvironmentData environmentData;
            if(File.Exists(_envPath))
            {
                var formatter = new BinaryFormatter();
                {
                    using (var fs = new FileStream(_envPath, FileMode.Open))
                    {
                        environmentData = formatter.Deserialize(fs) as EnvironmentData;
                        fs.Close();
                        return environmentData;
                    }
                }
            }
            else
            {
                Debug.Log("[SaveSystem] Environment save file does not exist!");
                return null;
            }
        }

        #endregion
        
        

        
    }
}

