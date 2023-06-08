using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
   public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void DeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    public void VictoryScreen()
    {
        SceneManager.LoadScene("VictoryScreen");
    }
}
