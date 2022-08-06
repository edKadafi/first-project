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
            obj.transform.SetPositionAndRotation(teleporter.transform.position + new Vector3(0, 1.9f, 0), obj.transform.rotation);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }
}

