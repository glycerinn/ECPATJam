using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public bool bookClicked = false;
    public bool cookClicked = false;
    public bool serveClicked = false;
    public GameObject tutorialBook;
    public GameObject customerPrefab;
    public List<GameObject> Stuff;
    int ingredientCount = 0;
    int requiredIngredients = 0;
    
    public Transform spawnPoint;
    public Transform counterPoint;
    public Transform exitPoint;
    public LevelLoader levelLoader;

    TaskCompletionSource<bool> waitSource;
    CustomerBehaviour currentCustomer;
   
    void Start()
    {
        dialogueRunner.AddCommandHandler("show_book", ShowBook);
        dialogueRunner.AddCommandHandler("wait_for_book", WaitForBook);
        dialogueRunner.AddCommandHandler("show_stuff", ShowStuff);
        dialogueRunner.AddCommandHandler<int>("wait_for_pot_ingredients", WaitForPotIngredients);
        dialogueRunner.AddCommandHandler("wait_for_serve", WaitForServe);
        dialogueRunner.AddCommandHandler("customer_leave", CustomerLeave);
    }

    public void CustomerLeave()
    {
        StartCoroutine(CustomerLeaveRoutine());
    }

    IEnumerator CustomerLeaveRoutine()
    {
        yield return currentCustomer.MoveTo(exitPoint.position);

        Destroy(currentCustomer.gameObject);

        StartCoroutine(levelLoader.PlayNextTransition());
    }

    public void ShowBook()
    {
        tutorialBook.SetActive(true);
    }

    public void ShowStuff()
    {
        foreach(GameObject gameObject in Stuff)
        {
            gameObject.SetActive(true);
        }
        
    }

    public IEnumerator WaitForBook()
    {
        bookClicked = false;

        while (!bookClicked)
        {
            yield return null;
        }
    }

    public IEnumerator WaitForServe()
    {
        cookClicked = false;
        serveClicked = false;

        while(!cookClicked || !serveClicked)
        {
            yield return null;
        }
    }

    public void ClickBook()
    {
        bookClicked = true;
    }

    public void clickCook()
    {
        cookClicked = true;
    }

    public void ClickServe()
    {
        serveClicked = true;
    }

    public async YarnTask WaitForPotIngredients(int amount)
    { 
        ingredientCount = 0;
        requiredIngredients = amount;
        waitSource = new TaskCompletionSource<bool>();
        await waitSource.Task;
    }
    
    public void IngredientAdded()
    {
        ingredientCount++;
        if (ingredientCount >= requiredIngredients)
        {
            waitSource?.SetResult(true);
        }
    }

    public IEnumerator SpawnOfficer()
    {
        GameObject obj = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
        currentCustomer = obj.GetComponent<CustomerBehaviour>();
        yield return currentCustomer.MoveTo(counterPoint.position);
    }
}
