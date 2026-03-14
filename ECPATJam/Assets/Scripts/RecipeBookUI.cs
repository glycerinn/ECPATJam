using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class RecipeBookUI : MonoBehaviour
{
    public List<RecipeSO> recipes;

    public Transform buttonParent;
    public GameObject recipeButtonPrefab;

    public TMP_Text recipeName;
    public TMP_Text ingredientText;
    public TMP_Text descriptionText;
    public Image recipeImage;

    void Start()
    {
        GenerateRecipeButtons();
    }

    public void GenerateRecipeButtons()
    {
        foreach (RecipeSO recipe in recipes)
        {
            GameObject obj = Instantiate(recipeButtonPrefab, buttonParent);

            RecipeButton button = obj.GetComponent<RecipeButton>();
            button.Initialize(recipe, this);

            Debug.Log("Creating button for " + recipe.ResultRecipe);
        }
    }

    public void DisplayRecipe(RecipeSO recipe)
    {
        recipeName.text = recipe.ResultRecipe;
        recipeImage.sprite = recipe.RecipeSprite;

        ingredientText.text = "";

        foreach (MaterialSO mat in recipe.materials)
        {
            ingredientText.text += "- " + mat.name + "\n";
        }

        descriptionText.text = recipe.description;
    }
}
