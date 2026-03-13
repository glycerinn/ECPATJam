using UnityEngine;
using TMPro;

public class RecipeButton : MonoBehaviour
{
    public TMP_Text nameText;

    RecipeSO recipe;
    RecipeBookUI recipeBook;

    public void Initialize(RecipeSO r, RecipeBookUI book)
    {
        recipe = r;
        recipeBook = book;
        nameText.text = r.ResultRecipe;
    }

    public void Click()
    {
        recipeBook.DisplayRecipe(recipe);
    }
}
