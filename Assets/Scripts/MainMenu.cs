using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject PlayMenu;
    public GameObject SettingsMenu;

    public Button MusicButton;
    public AudioSource backgroundMusic;
    public TMP_InputField playerName;
    bool nameChanged = false;

    private void Awake()
    {
        Menu.SetActive(true);
        SettingsMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }

    public void OnHowToPlayClick()
    {
        Menu.SetActive(false);
        PlayMenu.SetActive(true);
    }

    public void OnSettingsClick()
    {
        Menu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void OnBackClick()
    {
        Menu.SetActive(true);
        SettingsMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }

    public void OnChange_Name()
    {
        nameChanged = true;
    }

    public void OnContinueClick()
    {
        if(nameChanged == true && playerName.text != "")
        {
            Globals.playerName = playerName.text;
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }

    public void OnMusicVolumeClick()
    {
        if (Globals.musicVolume == true)
        {
            backgroundMusic.Stop();
            MusicButton.GetComponentInChildren<Text>().text = "Music Volume: OFF";
            Globals.musicVolume = false;
        }
        else
        {
            backgroundMusic.Play();
            MusicButton.GetComponentInChildren<Text>().text = "Music Volume: ON";
            Globals.musicVolume = true;
        }
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
