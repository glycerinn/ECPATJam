using UnityEngine;
using UnityEngine.SceneManagement;

public class DayFinishScript : MonoBehaviour
{
    private int currentSceneIndex;

    public void LoadMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void NextDay()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
