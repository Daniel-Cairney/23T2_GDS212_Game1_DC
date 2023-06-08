using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransactor : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LoadMainScene();
        }
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("Main Scene"); // Replace "MainScene" with the name of your main scene
    }
}