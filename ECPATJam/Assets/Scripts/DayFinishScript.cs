using UnityEngine;
using UnityEngine.SceneManagement;

public class DayFinishScript : MonoBehaviour
{
    private int currentSceneIndex;
    public LevelLoader levelLoader;

    public void LoadMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        Time.timeScale = 1f;
        StartCoroutine(levelLoader.PlayBackTransition());
    }

    public void NextDay()
    {
        StartCoroutine(levelLoader.PlayNextTransition());
    }
}
