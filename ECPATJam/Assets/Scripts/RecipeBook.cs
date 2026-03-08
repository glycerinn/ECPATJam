using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    private List<RecipeSO> recipes;

    public string CheckMaterials(List<MaterialSO> inPotMaterials)
    {
        foreach(RecipeSO recipe in recipes)
        {
            if(MatchRecipe(inPotMaterials, recipe.materials))
            {
                return recipe.ResultRecipe;
            }
        }

        return "Slop";
    }

    bool MatchRecipe(List<MaterialSO> inPot, List<MaterialSO> recipes)
    {
        if(inPot.Count != recipes.Count)
            return false;
            
        List<MaterialSO> inPotSorted = new List<MaterialSO>(inPot);
        List<MaterialSO> recipeSorted = new List<MaterialSO>(recipes);

        inPotSorted.Sort((a, b) => a.name.CompareTo(b.name));
        recipeSorted.Sort((a, b) => a.name.CompareTo(b.name));

        for(int i = 0; i < inPotSorted.Count; i++)
        {
            if(inPotSorted != recipeSorted)
            {
                return false;
            }
        }

        return true;
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
