using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource SFX;

    [SerializeField] AudioClip MainMenubg;
    [SerializeField] AudioClip GameBg;
    public AudioClip[] Grab;
    public AudioClip[] Pot;
    public AudioClip ButtonSFX;
    private bool isPaused = false;

    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    public void playMainMenuBGM()
    {
        BGM.clip = MainMenubg;
        BGM.Play();
    }

    public void playGameBGM()
    {
        if (isPaused) return;
        BGM.clip = GameBg;
        BGM.Play();
    }

    public void playGrab()
    {
        if (isPaused) return;
        int rand = Random.Range(0, Grab.Length);
        SFX.PlayOneShot(Grab[rand]);
    }

    public void playHitPot()
    {
        if (isPaused) return;
        int rand = Random.Range(0, Grab.Length);
        SFX.PlayOneShot(Pot[rand]);
    }

    public void playButtonSFX()
    {
        SFX.PlayOneShot(ButtonSFX);
        Debug.Log("click");
    }

    public void StopBGM()
    {
        BGM.Stop();
    }

    public void PausedSound()
    {
        isPaused = true;
    }
}