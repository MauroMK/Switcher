using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject pauseMenu;

    private bool isPaused = false;

    private void Awake() 
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion

        DontDestroyOnLoad(gameObject);  
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void RestartGame()
    {
        AudioManager.instance.PlaySound("Death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSpecificScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void LoadNextScene()
    {
        // Obtém o índice da cena atual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carrega a próxima cena
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
