using UnityEngine;

public class RecipeBehaviour : MonoBehaviour
{
    public SpriteRenderer sr;

    public void ShowDish(RecipeSO recipeSO)
    {
         if(recipeSO == null)
        {
            Debug.Log("Recipe failed");
            return;
        }

        sr.sprite = recipeSO.RecipeSprite;
    }

}
