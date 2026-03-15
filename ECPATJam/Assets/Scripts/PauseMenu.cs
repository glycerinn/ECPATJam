using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private int currentSceneIndex;
    public LevelLoader levelLoader;
    public GameObject pauseMenuUI;
    public static bool GameisPaused = false;
    private AudioManager audioManager;

    public void Awake()
    {
        GameObject audioObj = GameObject.FindGameObjectWithTag("AudioManager");

        if (audioObj != null)
        {
            audioManager = audioObj.GetComponent<AudioManager>();
            Debug.Log("found");
        }
        else
        {
            Debug.LogError("AudioManager not found in scene!");
        }
            
    }

    public void Start()
    {
        audioManager.playGameBGM();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                // AudioManager.instance.PausedSound();
                Pause();
            }
        }
    }

    public void Resume()
    {
        audioManager.playButtonSFX();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Pause()
    {
        audioManager.playButtonSFX();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void LoadMenu()
    {
        audioManager.playButtonSFX();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        Time.timeScale = 1f;
        StartCoroutine(levelLoader.PlayBackTransition());
    }
}
