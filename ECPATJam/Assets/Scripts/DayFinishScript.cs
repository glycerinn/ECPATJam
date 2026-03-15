using UnityEngine;
using UnityEngine.SceneManagement;

public class DayFinishScript : MonoBehaviour
{
    private int currentSceneIndex;
    public LevelLoader levelLoader;
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

    public void LoadMenu()
    {
        audioManager.StopBGM();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        StartCoroutine(levelLoader.PlayBackTransition());
    }

    public void NextDay()
    {
        StartCoroutine(levelLoader.PlayNextTransition());
    }
}
