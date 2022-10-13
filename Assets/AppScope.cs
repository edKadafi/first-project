using Proiect.GamePlay;
using Proiect.UI;
using UnityEngine;

public class AppScope : MonoBehaviour
{
    [SerializeField] private UI ui;
    private UI uiinstance = null;
    private void Awake()
    {
        if (GameObject.Find("UI(Clone)") == null)
        {
            uiinstance = Instantiate(ui);
            DontDestroyOnLoad(uiinstance);
        }
        else
        {
            UI.System.transform.Find("MainMenuPopup").gameObject.SetActive(true);
        }
    }
}