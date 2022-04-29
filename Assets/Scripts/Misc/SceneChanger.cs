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
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("SecondLevel");
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene("ThirdLevel");
    }
}
