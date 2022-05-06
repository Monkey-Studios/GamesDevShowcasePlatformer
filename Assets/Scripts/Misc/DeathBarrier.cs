using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FirstLevel"))
        {
            SceneManager.LoadScene("GameOverLevelOne");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SecondLevel"))
        {
            SceneManager.LoadScene("GameOverLevelTwo");
        }
        else
        {
            SceneManager.LoadScene("GameOverLevelThree");
        }
    }
}
