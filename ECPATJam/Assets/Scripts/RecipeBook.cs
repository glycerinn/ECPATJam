using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public List<RecipeSO> recipes;

    public RecipeSO CheckMaterials(List<MaterialSO> inPotMaterials)
    {
        foreach(RecipeSO recipe in recipes)
        {
            if(MatchRecipe(inPotMaterials, recipe.materials))
            {
                Debug.Log("Recipe Found: " + recipe.ResultRecipe);
                return recipe;
            }
        }

        return null;
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

}
