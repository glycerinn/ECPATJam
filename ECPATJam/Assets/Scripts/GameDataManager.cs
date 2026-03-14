using UnityEngine;
using TMPro;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    public string playerName;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
