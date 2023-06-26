using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoadMenager : MonoBehaviour
{
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName); 
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
