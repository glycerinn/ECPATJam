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
    List<SpriteRenderer> dishSprites = new List<SpriteRenderer>();
    [SerializeField] float stackHeight = 0.15f;

    List<RecipeSO> cookedDishes = new List<RecipeSO>();

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

    void Start()
    {
        
    }

    public void ConsumeDishes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (cookedDishes.Count == 0)
                break;

            cookedDishes.RemoveAt(cookedDishes.Count - 1);
        }

        UpdateDishDisplay();
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

        CreateDishSprite(recipeSO);
    }

    public void TrashLatestDish()
    {
        audioManager.playButtonSFX();
        if (cookedDishes.Count == 0)
        {
            Debug.Log("No dishes to trash");
            return;
        }

        cookedDishes.RemoveAt(cookedDishes.Count - 1);

        RemoveTopDishSprite();
        UpdateDishDisplay();
    }

    public void ServeDish()
    {
        audioManager.playButtonSFX();
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

        RemoveTopDishSprite();

        UpdateDishDisplay();
    }

    void CreateDishSprite(RecipeSO recipe)
    {
        GameObject dishObj = new GameObject("Dish");

        dishObj.transform.SetParent(transform);

        int index = dishSprites.Count;

        dishObj.transform.localPosition = new Vector3(0, stackHeight * index, 0);

        SpriteRenderer newSR = dishObj.AddComponent<SpriteRenderer>();
        newSR.sprite = recipe.RecipeSprite;

        newSR.sortingLayerID = sr.sortingLayerID;
        newSR.sortingOrder = sr.sortingOrder + index;

        dishSprites.Add(newSR);
    }

    void RemoveTopDishSprite()
    {
        if (dishSprites.Count == 0)
            return;

        SpriteRenderer top = dishSprites[dishSprites.Count - 1];

        dishSprites.RemoveAt(dishSprites.Count - 1);

        Destroy(top.gameObject);
    }

    void UpdateDishDisplay()
    {
        for (int i = 0; i < dishSprites.Count; i++)
        {
            dishSprites[i].transform.localPosition = new Vector3(0, stackHeight * i, 0);
            dishSprites[i].sortingOrder = i;
        }
    }

    public int GetDishCount()
    {
        return cookedDishes.Count;
    }
    
}
