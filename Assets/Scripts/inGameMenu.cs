using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inGameMenu : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI score;
    public TextMeshProUGUI lives;

    private void Update()
    {
        score.text = Globals.gameScore.ToString();
        lives.text = Globals.lives.ToString();
    }

    public void onbuttonClick()
    {
        menu.SetActive(true);
        Globals.paused = true;
        //pause the speed/running here
    }

    public void OnResumeClick()
    {
        menu.SetActive(false);
        Globals.paused = false;
        //resume speed/running here
    }

    public void OnMainMenuClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
}
