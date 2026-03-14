using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private int currentSceneIndex;
    public LevelLoader levelLoader;

    public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
       
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
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameisPaused = false;
        }

        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameisPaused = true;
        }

        public void LoadMenu()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
            Time.timeScale = 1f;
            StartCoroutine(levelLoader.PlayBackTransition());
        }
}
