using UnityEngine;
using System.Collections.Generic;

public class TutorialPot : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public List<MaterialSO> materials = new List<MaterialSO>();
    public List<MaterialBehaviour> materialsInPot = new List<MaterialBehaviour>();
    public RecipeBook recipeBook;
    public RecipeBehaviour recipeBehaviour;

    public void AddMaterial(MaterialBehaviour material)
    {
        tutorialManager.IngredientAdded();
        materials.Add(material.GetMaterial());
        materialsInPot.Add(material);
        Debug.Log("Added: " + material.GetMaterial());
    }

    public void CookMaterial()
    {
        RecipeSO recipe = recipeBook.CheckMaterials(materials);

        recipeBehaviour.ShowDish(recipe);

        foreach(MaterialBehaviour materialBehaviour in materialsInPot)
        {
            materialBehaviour.ResetPosition();
        }

        materials.Clear();
        materialsInPot.Clear();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        MaterialBehaviour material = collision.GetComponent<MaterialBehaviour>();
        
        if(material != null)
        {
            AddMaterial(material);
            collision.gameObject.SetActive(false);
        }
    }
}
