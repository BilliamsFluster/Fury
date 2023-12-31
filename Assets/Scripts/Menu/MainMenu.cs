using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject canvasToDisable;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the main level
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    private void Awake()
    {
        if (canvasToDisable != null)
        {
            canvasToDisable.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Canvas to disable is not assigned!");
        }
    }
}
