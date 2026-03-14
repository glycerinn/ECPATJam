using UnityEngine;
using TMPro;
using Yarn.Unity;
using System.Collections;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public DialogueRunner dialogueRunner;
    public TutorialManager tutorialManager;
    public GameObject inputCanvas;

    public void SubmitName()
    {
        string playerName = inputField.text;
        GameDataManager.Instance.playerName = inputField.text;

        if (string.IsNullOrWhiteSpace(playerName))
        playerName = "Player";

        dialogueRunner.VariableStorage.SetValue("$playerName", playerName);
        PlayerPrefs.SetString("playerName", playerName);
        
        inputCanvas.SetActive(false);
        
        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        dialogueRunner.StartDialogue("Intro");

        while (dialogueRunner.IsDialogueRunning)
            yield return null;

        yield return StartCoroutine(tutorialManager.SpawnOfficer());

        dialogueRunner.StartDialogue("FirstStep");
    }
}
