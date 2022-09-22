using Proiect.GamePlay;
using Proiect.UI;
using UnityEngine;


public class AppScope : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private UI ui;

    private void Awake()
    {
        var uiinstance = Instantiate(ui);
        DontDestroyOnLoad(uiinstance);
        var gameinstance = Instantiate(game, this.transform, true);
    }
}