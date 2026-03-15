using System;
using System.Collections.Generic;
using UnityEngine;

public class PotBehaviour : MonoBehaviour
{
    public List<MaterialSO> materials = new List<MaterialSO>();
    public List<MaterialBehaviour> materialsInPot = new List<MaterialBehaviour>();
    public RecipeBook recipeBook;
    public RecipeBehaviour recipeBehaviour;
    private AudioManager audioManager;
    
    public void Awake()
    {
        GameObject audioObj = GameObject.FindGameObjectWithTag("AudioManager");

        if (audioObj != null)
        {
            audioManager = audioObj.GetComponent<AudioManager>();
            Debug.Log("found");
        }
        else
        {
            Debug.LogError("AudioManager not found in scene!");
        }
            
    } 

    public void AddMaterial(MaterialBehaviour material)
    {
        materials.Add(material.GetMaterial());
        materialsInPot.Add(material);
        Debug.Log("Added: " + material.GetMaterial());
    }

    public void CookMaterial()
    {
        audioManager.playButtonSFX();
        RecipeSO recipe = recipeBook.CheckMaterials(materials);

        recipeBehaviour.ShowDish(recipe);

        foreach(MaterialBehaviour materialBehaviour in materialsInPot)
        {
            Destroy(materialBehaviour.gameObject);
        }

        materials.Clear();
        materialsInPot.Clear();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.playHitPot();
        MaterialBehaviour material = collision.GetComponent<MaterialBehaviour>();

        if(material != null)
        {
            AddMaterial(material);
            collision.gameObject.SetActive(false);
        }
    }
}
