using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public List<RecipeSO> recipes;
    public GameObject RecipePages;
    [SerializeField] RecipeSO failedRecipe;

    public RecipeSO CheckMaterials(List<MaterialSO> inPotMaterials)
    {
        if (inPotMaterials == null || inPotMaterials.Count == 0)
        {
            Debug.Log("Pot is empty");
            return null;
        }
        
        foreach(RecipeSO recipe in recipes)
        {
            if(MatchRecipe(inPotMaterials, recipe.materials))
            {
                Debug.Log("Recipe Found: " + recipe.ResultRecipe);
                return recipe;
            }
        }

        return failedRecipe;
    }

    bool MatchRecipe(List<MaterialSO> inPot, List<MaterialSO> recipes)
    {
        if(inPot.Count != recipes.Count)
            return false;
            
        foreach (MaterialSO ingredient in recipes)
        {
            if (!inPot.Contains(ingredient))
                return false;
        }

        return true;
    }

    public void ShowRecipes()
    {
        RecipePages.SetActive(true);
    }

}
