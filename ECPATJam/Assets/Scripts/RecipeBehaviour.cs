using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class RecipeBehaviour : MonoBehaviour
{
    public SpriteRenderer sr;
    public DialogueRunner dialogueRunner;
    [SerializeField] CustomerManager customerManager;
    RecipeSO currentRecipe;

    void Start()
    {
        sr.enabled = false;
    }

    public void ShowDish(RecipeSO recipeSO)
    {
        if(recipeSO == null)
        {
            Debug.Log("Recipe failed");
            return;
        }

        currentRecipe = recipeSO;
        sr.sprite = recipeSO.RecipeSprite;
        sr.enabled = true;

    }

    public void ServeDish()
    {
        TutorialManager tutorial = FindAnyObjectByType<TutorialManager>();

        if(tutorial != null || currentRecipe == customerManager.currentOrder)
        {
            dialogueRunner.VariableStorage.SetValue("$correctDish", true);
        }
        else
        {
            dialogueRunner.VariableStorage.SetValue("$correctDish", false);
            Debug.Log("Wrong dish!");
        }

        customerManager?.OrderServed();
        sr.enabled = false;
        currentRecipe = null;
    }
}
