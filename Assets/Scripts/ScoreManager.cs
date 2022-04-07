using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Creates public instance so it can be used else where in other scripts
    public static ScoreManager instance;
    //References to the text elements along with their default values
    public TextMeshProUGUI playerScoreTxt;
    public TextMeshProUGUI highScoreTxt;

    int playerScore = 0;
    int highScore = 0;
    //When the game loads an instance of this script is loaded, this means it is also loaded and can be used instantly in other scripts
    private void Awake()
    {
        instance = this;
    }
    //Creates links to the GUI text elements
    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore: ", 0);
        playerScoreTxt.text = "Score: " + playerScore.ToString();
        highScoreTxt.text = "Highscore: " + highScore.ToString();
    }
    //Adds 1 score to the player and updates on the UI
    public void AddScore()
    {
        playerScore += 1;
        playerScoreTxt.text = "Score: " + playerScore.ToString();
        if(highScore < playerScore)
            PlayerPrefs.SetInt("Highscore: ", playerScore);
    }
}
