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

    // Start is called before the first frame update
    void Start()
    {
        //on game end: PlayerPrefs.SetInt("Score", score);
        //currentScore = PlayerPrefs.GetInt("Score", 0);
        currentScore = 4;

        Globals.names[0] = "Chicken";
        Globals.names[1] = "Wing";
        Globals.names[2] = "Head";
        Globals.names[3] = "Leg";
        Globals.names[4] = "Foot";

        Globals.score[0] = 10;
        Globals.score[1] = 8;
        Globals.score[2] = 6;
        Globals.score[3] = 3;
        Globals.score[4] = 2;


        foreach (int score in Globals.score)
        {
            if (currentScore <= score)
            {
                scorePosition = position;
            }
            position++;
        }
        scorePosition++;

        if (scorePosition < 4)
        {
            for (int i = (Globals.names.Length - 1); i >= scorePosition; i--)
            {
                Globals.names[i] = Globals.names[i - 1];
                Globals.score[i] = Globals.score[i - 1];
            }
            
        }
        if(scorePosition == 4)
        {
            Globals.names[scorePosition] = newname;
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
