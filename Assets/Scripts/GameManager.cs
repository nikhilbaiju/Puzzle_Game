using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject gameOver;

    public int count;


    private void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    private void OnEnable()
    {
        GameEvent.OnActive_GameOver += ActiveGameOverPanel;
        GameEvent.OnActive_Win += ActiveWinPanel;

    }

    private void OnDisable()
    {
        GameEvent.OnActive_GameOver -= ActiveGameOverPanel;
        GameEvent.OnActive_Win -= ActiveWinPanel;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ActivePausePanel();
        }


    }

    public void Resume()
    {

        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {
        Debug.Log("Restart");
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the current scene again
        SceneManager.LoadScene(currentSceneName);
    }

    public void NextLevel()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        count++;

        Debug.Log(count);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    /*************************************/

    

    //Active Pause
    public void ActivePausePanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ActiveWinPanel()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    public void ActiveGameOverPanel()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

}
