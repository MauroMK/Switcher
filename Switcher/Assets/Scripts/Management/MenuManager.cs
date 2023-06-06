using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Obtém o índice da cena atual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carrega a próxima cena
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void GoToSettingsPanel()
    {
        
    }

    public void GoToMainMenu()
    {

    }
}
