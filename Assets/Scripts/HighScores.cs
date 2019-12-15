﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public TMPro.TextMeshProUGUI names;
    public TMPro.TextMeshProUGUI scores;
    int currentScore;
    int scorePosition = 0;
    int position = 0;

    void Start()
    {
        currentScore = Globals.gameScore;
        foreach (int score in Globals.score)
        {
            if (currentScore <= score)
            {
                scorePosition = position;
            }
            position++;
        }
        //scorePosition++;

        foreach (string name in Globals.names)
        {
            name.ToLower();
        }

        Debug.Log("Player name from globals " + Globals.playerName);
        Debug.Log("scoreposition " + scorePosition);
        Debug.Log("score " + Globals.score);
        if (scorePosition < 4)
        {
            for (int i = (Globals.names.Length - 1); i >= scorePosition; i--)
            {
                Globals.names[i] = Globals.names[i];
                Globals.score[i] = Globals.score[i];
            }
            Globals.names[scorePosition] = Globals.playerName.ToUpper();
            Globals.score[scorePosition] = currentScore;
        }
        if(scorePosition == 4)
        {
            Globals.names[scorePosition] = Globals.playerName.ToUpper();
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
