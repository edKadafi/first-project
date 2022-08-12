using System;
using System.Collections;
using System.Collections.Generic;
using Proiect.GamePlay;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Proiect.UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Transform pauseMenu;
        private Transform pmenu;
        private void Awake()
        {
            if (FindObjectOfType<EventSystem>() == null)
            {
                var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
            }
            pmenu = Instantiate(pauseMenu);
            pmenu.SetParent(this.transform);
            pmenu.gameObject.SetActive(false);
            Debug.Log("Awake: " + pmenu.gameObject.activeSelf);
        }
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                if (pmenu != null)
                {
                    if (pmenu.gameObject.activeSelf == true)
                    {
                        pmenu.gameObject.SetActive(false);
                        GameStateManager.ChangeState(2);
                        Debug.Log("[GameStateManager] Game State = "+GameStateManager.GetCurrentState().GetName());
                        Debug.Log("[UI] Pause Menu State: "+pmenu.gameObject.activeSelf);
                    }
                    else
                    {
                        pmenu.gameObject.SetActive(true);
                        GameStateManager.ChangeState(1);
                        Debug.Log("[GameStateManager] Game State = "+GameStateManager.GetCurrentState().GetName());
                        Debug.Log("[UI] Pause Menu State: "+pmenu.gameObject.activeSelf);
                    }
                }
            }
        }
    }
}

