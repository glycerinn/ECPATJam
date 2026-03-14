using UnityEngine;
using Yarn.Unity;

public class LoadPlayerName : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    void Start()
    {
        string name = GameDataManager.Instance.playerName;

        if (string.IsNullOrEmpty(name))
        {
            name = PlayerPrefs.GetString("playerName", "Player");
            GameDataManager.Instance.playerName = name;
        }

        dialogueRunner.VariableStorage.SetValue("$playerName", name);
    }
}
