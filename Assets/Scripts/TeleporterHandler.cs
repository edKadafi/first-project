using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proiect.GamePlay.Inanimates.Teleporter
{
    
    public static class TeleporterHandler
    {
        private static List<GameObject> teleporters;
    
        public static void Teleport(GameObject obj, GameObject teleporter)
        {
            teleporter.GetComponentInChildren<TeleporterTrigger>().setEnteredTrue();
            obj.transform.SetPositionAndRotation(teleporter.transform.position + new Vector3(2, 1.88f, 0), new Quaternion(0, 0, 0, 0));
        }
    }
}

