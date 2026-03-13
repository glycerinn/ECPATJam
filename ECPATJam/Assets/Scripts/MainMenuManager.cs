using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // public GameObject Credits;
    public LevelLoader levelLoader;
    // private AudioManager audioManager;
    private int sceneToContinue;


    public void Awake()
    {
        // audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    } 

    public void Start()
    {
        // AudioManager.instance.playLobbyBGM();
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        StartCoroutine(levelLoader.PlayTutorialTransition());
        // audioManager.playButtonSFX();
    }

    public void CreditsShow()
    {   
        // audioManager.playButtonSFX();
        // Credits.SetActive(true);
    }
    
    public void CreditsUnShow()
    {
        // audioManager.playButtonSFX();
        // Credits.SetActive(false);
    }

    public void QuitGame()
    {
        // audioManager.playButtonSFX();
        Application.Quit();
    }

    public void ContinueButton()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        if(sceneToContinue != 0)
        {
            StartCoroutine(levelLoader.PlayContinueTransition(sceneToContinue));
        }
        else
        {
            return;
        }

    }
}
