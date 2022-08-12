using System.Collections;
using System.Collections.Generic;
using Proiect.Player;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private RectTransform recTransf;

    private MainPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        recTransf = GetComponentInParent<RectTransform>();
        player = PlayerManager.Player;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        var aux = recTransf.rect.height;
        recTransf.sizeDelta =new Vector2(player.GetHp(), aux);
    }
}
