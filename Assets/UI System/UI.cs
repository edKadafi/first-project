using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
                    Debug.Log("[UI] Pause Menu State: "+pmenu.gameObject.activeSelf);
                }
                else
                {
                    pmenu.gameObject.SetActive(true);
                    Debug.Log("[UI] Pause Menu State: "+pmenu.gameObject.activeSelf);
                }
            }
        }
    }
}
