using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Yarn.Unity;

public class RecipeBehaviour : MonoBehaviour
{
    public SpriteRenderer sr;
    public DialogueRunner dialogueRunner;
    [SerializeField] int maxDishes = 3;
    [SerializeField] CustomerManager customerManager;

    List<RecipeSO> cookedDishes = new List<RecipeSO>();

    void Start()
    {
        sr.enabled = false;
    }

    public void ShowDish(RecipeSO recipeSO)
    {
        if (recipeSO == null)
        {
            Debug.Log("Recipe failed");
            return;
        }

        if (cookedDishes.Count >= maxDishes)
        {
            Debug.Log("Counter is full!");
            return;
        }

        customerManager?.DishCooked();

        cookedDishes.Add(recipeSO);

        UpdateDishDisplay();
    }

    public void ServeDish()
    {
        if (cookedDishes.Count == 0)
            return;

        RecipeSO servedDish = cookedDishes[cookedDishes.Count - 1];
        cookedDishes.RemoveAt(cookedDishes.Count - 1);

        bool rightDish = false;

        TutorialManager tutorial = FindAnyObjectByType<TutorialManager>();

        if (tutorial != null)
            rightDish = true;
        else if (customerManager.currentOrder == null)
            rightDish = true;
        else if (servedDish == customerManager.currentOrder)
            rightDish = true;

        dialogueRunner.VariableStorage.SetValue("$correctDish", rightDish);

        customerManager?.OrderServed();

        UpdateDishDisplay();
    }

    void UpdateDishDisplay()
    {
        if (cookedDishes.Count == 0)
        {
            sr.enabled = false;
            return;
        }

        sr.sprite = cookedDishes[cookedDishes.Count - 1].RecipeSprite;
        sr.enabled = true;
    }
    
}
