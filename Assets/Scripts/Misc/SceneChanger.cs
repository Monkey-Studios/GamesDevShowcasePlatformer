using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void CloseGame()
    {
        Debug.Log("Game has closed");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOverLevelOne"))
        {
            SceneManager.LoadScene("FirstLevel");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOverLevelTwo"))
        {
            SceneManager.LoadScene("SecondLevel");
        }
        else
        {
            SceneManager.LoadScene("ThirdLevel");
        }
    }
    public void ProgressLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("YouWinLevelOne")) 
        {
            SceneManager.LoadScene("SecondLevel");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("YouWinLevelTwo")) 
        {
            SceneManager.LoadScene("ThirdLevel");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("FirstLevel");
    }
 
}
