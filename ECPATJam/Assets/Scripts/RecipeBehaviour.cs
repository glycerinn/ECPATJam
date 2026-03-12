using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeBehaviour : MonoBehaviour
{
    public SpriteRenderer sr;
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
            customerManager?.OrderServed();
        }
        else
        {
            Debug.Log("Wrong dish!");
        }

        sr.enabled = false;
        currentRecipe = null;
    }
}
