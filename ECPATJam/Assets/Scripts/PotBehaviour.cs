using System.Collections.Generic;
using UnityEngine;

public class PotBehaviour : MonoBehaviour
{
    public List<MaterialSO> materials = new List<MaterialSO>();
    public RecipeBook recipeBook;
    public RecipeBehaviour recipeBehaviour;

    public void AddMaterial(MaterialSO materialname)
    {
        materials.Add(materialname);
        Debug.Log("Added: " + materialname.name);
    }

    public void CookMaterial()
    {
        RecipeSO recipe = recipeBook.CheckMaterials(materials);

        recipeBehaviour.ShowDish(recipe);

        materials.Clear();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        MaterialBehaviour material = collision.GetComponent<MaterialBehaviour>();

        if(material != null)
        {
            AddMaterial(material.GetMaterial());
            collision.gameObject.SetActive(false);
        }
    }
}
