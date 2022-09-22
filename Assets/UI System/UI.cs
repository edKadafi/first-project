using System;
using System.Collections;
using System.Collections.Generic;
using Proiect.Game.States;
using Proiect.GamePlay;
using UnityEngine;
using UnityEngine.EventSystems;

//UI system as singleton to access it from anywhere
namespace Proiect.UI
{
    public class UI : MonoBehaviour
    {
        public static UI System { get; private set; }
        [SerializeField] private Transform pauseMenu;
        [SerializeField] private Transform healthBar;
        private static Transform _healthBarInstance;


        private Transform pmenu;

        private void Awake()
        {
            //Checking to see if any other instances of the singleton exist so that we only ever have one at any time
            if (System != null && System != this)
            {
                Destroy(this);
            }
            else
            {
                System = this;
            }

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
                    }
                    else
                    {
                        pmenu.gameObject.SetActive(true);
                    }
                }
            }
        }

        public void EnableHealthBar()
        {
            _healthBarInstance.gameObject.SetActive(true);
        }

        public void DisableHealthBar()
        {
            _healthBarInstance.gameObject.SetActive(false);
        }

        public void InstantiateHealthBar()
        {
            //Instantiating the health bar when it is enabled
            _healthBarInstance = Instantiate(healthBar);
            _healthBarInstance.transform.SetParent(this.transform);
        }
    }
}