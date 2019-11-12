using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    private bool helps = false;
    public bool MainMenu = true;
    public GameObject helpPanel;
    public GameObject helpButton;
    private Text helpButtonT;
    private Text uid;
    void Start()
    {
        if (MainMenu)
        {
            helpPanel.SetActive(false);
            helpButtonT = helpButton.GetComponent<UnityEngine.UI.Text>();
            uid = helpPanel.GetComponent<UnityEngine.UI.Text>();
            helpButtonT.text = "Help ->";
        }
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    public void loadLevel(int levelid)
    {
        Application.LoadLevel(levelid);
    }
    public void applicationHelp()
    {
        if (!helps) {
            helps = true;
            helpButtonT.text = "Help <-";
            helpPanel.SetActive(true);
            uid.text = "You must collect the Yellow cubes.\nDon't crash into the Walls!";
        } else {
            uid.text = "";
            helps = false;
            helpButtonT.text = "Help ->";
            helpPanel.SetActive(false);
        }
    }
}
