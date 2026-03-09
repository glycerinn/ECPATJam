using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipes")]
public class RecipeSO : ScriptableObject
{
    public string ResultRecipe;
    public List<MaterialSO> materials;
    public Sprite RecipeSprite;
}
