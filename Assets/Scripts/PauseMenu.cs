using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    void Start() => SetPaused(false);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPaused(!pausePanel.activeSelf);
    }

    public void Resume() => SetPaused(false);

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void SetPaused(bool paused)
    {
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0f : 1f;
    }
}