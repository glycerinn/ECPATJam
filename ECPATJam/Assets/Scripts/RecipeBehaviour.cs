using UnityEngine;

public class RecipeBehaviour : MonoBehaviour
{
    public SpriteRenderer sr;
    public CustomerManager customerManager;
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
        Debug.Log(currentRecipe);
        Debug.Log(customerManager.currentOrder);
        sr.sprite = recipeSO.RecipeSprite;
        sr.enabled = true;

    }

    public void ServeDish()
    {
        if(currentRecipe == customerManager.currentOrder)
        {
            customerManager.OrderServed();
        }
        else
        {
            Debug.Log("Wrong dish!");
        }

        sr.enabled = false;
        currentRecipe = null;
    }
}
