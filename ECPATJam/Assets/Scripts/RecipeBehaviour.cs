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
        bool rightDish = false;
        TutorialManager tutorial = FindAnyObjectByType<TutorialManager>();

        if(tutorial != null || currentRecipe == customerManager.currentOrder)
        {
            rightDish = true;
        }
        else if(customerManager.currentOrder == null)
        {
            rightDish = true;
        }

        dialogueRunner.VariableStorage.SetValue("$correctDish", rightDish);
        customerManager?.OrderServed();
        
        sr.enabled = false;
        currentRecipe = null;
    }
}
