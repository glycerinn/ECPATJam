using UnityEngine;

public class RecipeBehaviour : MonoBehaviour
{
    public SpriteRenderer sr;

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

        sr.sprite = recipeSO.RecipeSprite;
        sr.enabled = true;

    }

    public void ServeDish()
    {
        sr.enabled = false;
    }
}
