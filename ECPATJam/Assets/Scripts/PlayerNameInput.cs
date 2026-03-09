using UnityEngine;
using TMPro;
using Yarn.Unity;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public DialogueRunner dialogueRunner;
    public GameObject inputCanvas;

    public void SubmitName()
    {
        string playerName = inputField.text;
        GameManager.Instance.playerName = inputField.text;

        if (string.IsNullOrWhiteSpace(playerName))
        playerName = "Player";

        dialogueRunner.VariableStorage.SetValue("$playerName", playerName);
        dialogueRunner.StartDialogue("Intro");

        inputCanvas.SetActive(false);
    }
}
