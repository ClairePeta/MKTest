using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    //change to playerprefs
    string[] scoreNames = new string[5];
    int[] scoreScores = new int[5];

    public TMPro.TextMeshProUGUI names;
    public TMPro.TextMeshProUGUI scores;
    int currentScore;
    int scorePosition = 0;
    int position = 0;

    void Start()
    {
        /*PlayerPrefs.SetString("Name1", "a");
        PlayerPrefs.SetString("Name2", "b");
        PlayerPrefs.SetString("Name3", "c");
        PlayerPrefs.SetString("Name4", "d");
        PlayerPrefs.SetString("Name5", "e");

        PlayerPrefs.SetInt("Score1", 5);
        PlayerPrefs.SetInt("Score2", 4);
        PlayerPrefs.SetInt("Score3", 3);
        PlayerPrefs.SetInt("Score4", 2);
        PlayerPrefs.SetInt("Score5", 1);
        */
        
        for (int i = 0; i < 5; i++)
        {
            string scoreboardName = "Name" + (i+1).ToString();
            string scoreboardScore = "Score" + (i+1).ToString();
            scoreNames[i] = PlayerPrefs.GetString(scoreboardName);
            scoreScores[i] = PlayerPrefs.GetInt(scoreboardScore);
        }

        //gets the players score and compares it against the current scoreboard scores
        currentScore = Globals.gameScore;
        foreach (int score in scoreScores)
        {
            if (currentScore <= score)
            {
                scorePosition = position+1;
            }
            position++;
        }
        Debug.Log("scorePosition1" + scorePosition);
        scorePosition++;
        Debug.Log("scorePosition2" + scorePosition);
        //lowers all the names so that the current players name is in all caps
        foreach (string name in scoreNames)
        {
            name.ToLower();
        }
        //moves around the scoreboard if needed
        if (scorePosition < 4)
        {
            for (int i = (scoreNames.Length - 1); i >= scorePosition; i--)
            {
                scoreNames[i] = scoreNames[i-1];
                scoreScores[i] = scoreScores[i-1];
            }

            scorePosition--;
            Debug.Log("scorePosition3" + scorePosition);
            scoreNames[scorePosition] = Globals.playerName.ToUpper();
            scoreScores[scorePosition] = currentScore;
        }
        if(scorePosition == 4)
        {
            scoreNames[scorePosition] = Globals.playerName.ToUpper();
            scoreScores[scorePosition] = currentScore;
        }
        Debug.Log("scorePosition4" + scorePosition);
        for (int i = 0; i < 5; i++)
        {
            string scoreboardName = "Name" + (i + 1).ToString();
            string scoreboardScore = "Score" + (i + 1).ToString();

            PlayerPrefs.SetString(scoreboardName, scoreNames[i].ToLower());
            PlayerPrefs.SetInt(scoreboardScore, scoreScores[i]);
        }

        //sets the names and score to be displayed on the canvas
        names.text = (scoreNames[0] + "\n" + scoreNames[1] + "\n" + scoreNames[2] + "\n" + scoreNames[3] + "\n" + scoreNames[4]);
        scores.text = (scoreScores[0] + "\n" + scoreScores[1] + "\n" + scoreScores[2] + "\n" + scoreScores[3] + "\n" + scoreScores[4]);
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

}
