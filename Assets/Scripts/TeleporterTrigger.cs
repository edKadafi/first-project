using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Proiect.GamePlay.Inanimates.Teleporter
{
    public class TeleporterTrigger : MonoBehaviour
    {
        [SerializeField]
        private GameObject teleportLocation;

        private bool entered = false;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("[TeleportTrigger] Entered volume.");
            Debug.Log(entered);
        }

        private void OnTriggerStay(Collider other)
        {
            if (!entered)
            {
                Debug.Log(entered);
                setEnteredTrue();
                TeleporterHandler.Teleport(other.gameObject, teleportLocation);
                setEnteredTrue();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("[TeleportTrigger] Left volume.");
            Debug.Log("[Exit] Before: "+entered + GetInstanceID());
            setEnteredFalse();
            Debug.Log("[Exit] After: "+entered + GetInstanceID());
        }

        

        public void setEnteredTrue()
        {
            entered = true;
        }

        public void setEnteredFalse()
        {
            entered = false;
        }
    }
}

