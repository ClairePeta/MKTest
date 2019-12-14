using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inGameMenu : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI score;
    public TextMeshProUGUI lives;
    public GameObject countdownCanvas;

    private void Update()
    {
        score.text = Globals.gameScore.ToString();
        lives.text = Globals.lives.ToString();
    }

    public void onbuttonClick()
    {
        menu.SetActive(true);
        Globals.paused = true;
    }

    public void OnResumeClick()
    {
        menu.SetActive(false);
        StartCoroutine(ResumeGame(3));
    }

    public void OnMainMenuClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }

    private IEnumerator ResumeGame(float time)
    {
        countdownCanvas.SetActive(true);
        TextMeshProUGUI text = countdownCanvas.GetComponentInChildren<TextMeshProUGUI>();
        float elapsedTime = 0;

        while (elapsedTime / time < 1)
        {
            int counter = 3 - (int)elapsedTime;
            text.text = counter.ToString();
            yield return new WaitForEndOfFrame();

            elapsedTime += Time.deltaTime;
        }
        countdownCanvas.SetActive(false);
        Globals.paused = false;
    }
}
