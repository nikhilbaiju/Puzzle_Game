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

    //------------Panel Activation------------------------------
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

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ActivePausePanel();
        }


    }

    //--------------Level Manager-----------------
    public void Resume()
    {
        PlayButtonMusic();

        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        PlayButtonMusic();
        SceneManager.LoadScene("Main Menu");
        PlayMainMenuMusic();
    }

    public void Restart()
    {
        PlayButtonMusic();
        Debug.Log("Restart");
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the current scene again
        SceneManager.LoadScene(currentSceneName);
        PlayLevelMusic();
    }

    public void NextLevel()
    {
        PlayButtonMusic();
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        AudioManager.Instance.PlayLevelMusic();

        count++;

        Debug.Log(count);
    }

    public void Quit()
    {
        Application.Quit();
    }

    //---------------------Audio Control----------------
    public void PlayLevelMusic()
    {
        AudioManager.Instance.PlayLevelMusic();
    }

    public void PlayMainMenuMusic()
    {
        AudioManager.Instance.PlayMainMenuMusic();
    }

    public void PlayButtonMusic()
    {
        AudioManager.Instance.PlayButtonPressSound();
    }

    public void PlayTileChangeMusic()
    {
        AudioManager.Instance.PlayTileChangeSound();
    }
}
