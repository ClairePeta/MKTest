using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public TMPro.TextMeshProUGUI names;
    public TMPro.TextMeshProUGUI scores;
    int currentScore;
    string newname = "HELLO";
    int scorePosition = 20;
    int position = 0;

    void Start()
    {
        currentScore = Globals.gameScore;

        Globals.names[0] = "a";
        Globals.names[1] = "b";
        Globals.names[2] = "c";
        Globals.names[3] = "d";
        Globals.names[4] = "e";

        Globals.score[0] = 5;
        Globals.score[1] = 4;
        Globals.score[2] = 3;
        Globals.score[3] = 2;
        Globals.score[4] = 1;

        foreach (int score in Globals.score)
        {
            if (currentScore <= score)
            {
                scorePosition = position;
            }
            position++;
        }
        scorePosition++;

        foreach (string name in Globals.names)
        {
            name.ToLower();
        }

        if (scorePosition < 4)
        {
            for (int i = (Globals.names.Length - 1); i >= scorePosition; i--)
            {
                Globals.names[i] = Globals.names[i - 1];
                Globals.score[i] = Globals.score[i - 1];
            }
            Globals.names[scorePosition] = newname.ToUpper();
            Globals.score[scorePosition] = currentScore;
        }
        if(scorePosition == 4)
        {
            Globals.names[scorePosition] = newname.ToUpper();
            Globals.score[scorePosition] = currentScore;
        }

        names.text = (Globals.names[0] + "\n" + Globals.names[1] + "\n" + Globals.names[2] + "\n" + Globals.names[3] + "\n" + Globals.names[4]);
        scores.text = (Globals.score[0] + "\n" + Globals.score[1] + "\n" + Globals.score[2] + "\n" + Globals.score[3] + "\n" + Globals.score[4]);
    }

    public void OnMainMenuClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

}
