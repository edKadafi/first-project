using System;
using System.Collections;
using System.Collections.Generic;
using Proiect.Player;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private RectTransform recTransf;
    private bool _isActive = false;
    private MainPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        recTransf = GetComponentInParent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            UpdateHealthBar();
        }
    }

    public void UpdateHealthBar()
    {
        var aux = recTransf.rect.height;
        recTransf.sizeDelta =new Vector2(player.GetHp(), aux);
    }

    public void ChangeActiveState(bool value)
    {
        _isActive = value;
    }

    private void OnEnable()
    {
        
    }

    public void SetPlayer()
    {
        player = PlayerManager.Player;
        Debug.Log("[HealthBar] Player is: "+PlayerManager.Player);
    }
}
