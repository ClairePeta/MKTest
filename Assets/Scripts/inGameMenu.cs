using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenu : MonoBehaviour
{
    public GameObject menu;

    public void onbuttonClick()
    {
        menu.SetActive(true);
        //pause the speed/running here
    }

    public void OnResumeClick()
    {
        menu.SetActive(false);
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
