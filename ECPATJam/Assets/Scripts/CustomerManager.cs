using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yarn.Unity;

public class CustomerManager : MonoBehaviour
{
    public List<CustomerSO> customers;

    public GameObject customerPrefab;
    int dishesCooked = 0;
    int requiredDishes = 0;
    int remainingOrders;

    TaskCompletionSource<bool> cookWait;
    TaskCompletionSource<bool> orderWait;

    public Transform spawnPoint;
    public Transform counterPoint;
    public Transform exitPoint;

    public CustomerBehaviour currentCustomer;
    public DialogueRunner dialogueRunner;
    
    public RecipeSO currentOrder;
    public GameObject DayFinish;

    void Start()
    {
        dialogueRunner.AddCommandHandler("wait_for_order", WaitForOrder);
        dialogueRunner.AddCommandHandler("customer_leave", CustomerLeave);
        dialogueRunner.AddCommandHandler<int>("wait_for_cook", WaitForCookedDishes);
    }

    public async YarnTask WaitForOrder()
    {
        orderWait = new TaskCompletionSource<bool>();

        await orderWait.Task;
    }

    public async YarnTask WaitForCookedDishes(int amount)
    {
        dishesCooked = 0;
        requiredDishes = amount;

        cookWait = new TaskCompletionSource<bool>();

        await cookWait.Task;
    }

    public void DishCooked()
    {
        dishesCooked++;

        if (dishesCooked >= requiredDishes)
        {
            cookWait?.SetResult(true);
        }
    }

    public void CustomerLeave()
    {
        StartCoroutine(CustomerLeaveRoutine());
    }

    IEnumerator CustomerLeaveRoutine()
    {
        yield return currentCustomer.MoveTo(exitPoint.position);

        Destroy(currentCustomer.gameObject);
    }

    public void OrderServed()
    {
        remainingOrders--;

        if (remainingOrders <= 0)
        {
            orderWait?.SetResult(true);
        }
    }

    public IEnumerator StartDay()
    {
        foreach (CustomerSO customer in customers)
        {
            yield return SpawnCustomer(customer);
        }

        Debug.Log("Day complete");

        DayFinish.SetActive(true);
    }

    IEnumerator SpawnCustomer(CustomerSO data)
    {
        dialogueRunner.VariableStorage.SetValue("$correctDish", false);
        GameObject obj = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);

        currentCustomer = obj.GetComponent<CustomerBehaviour>();
        currentCustomer.Initialize(data);

        yield return currentCustomer.MoveTo(counterPoint.position);

        currentOrder = currentCustomer.GetOrder();
        remainingOrders = currentCustomer.data.orderAmount;

        dialogueRunner.StartDialogue(data.yarnNode);

        while (currentCustomer != null)
            yield return null;

        while (dialogueRunner.IsDialogueRunning)
            yield return null;
    }
}
