using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yarn.Unity;

public class CustomerManager : MonoBehaviour
{
    public List<CustomerSO> customers;

    public GameObject customerPrefab;

    public Transform spawnPoint;
    public Transform counterPoint;
    public Transform exitPoint;
    CustomerBehaviour currentCustomer;
    public DialogueRunner dialogueRunner;
    TaskCompletionSource<bool> orderWait;
    public RecipeSO currentOrder;
    public GameObject DayFinish;

    void Start()
    {
        dialogueRunner.AddCommandHandler("wait_for_order", WaitForOrder);
        dialogueRunner.AddCommandHandler("customer_leave", CustomerLeave);
    }

    public async YarnTask WaitForOrder()
    {
        orderWait = new TaskCompletionSource<bool>();

        await orderWait.Task;
    }

    public void CustomerLeave()
    {
        StartCoroutine(CustomerLeaveRoutine());
    }

    IEnumerator CustomerLeaveRoutine()
    {
        yield return currentCustomer.MoveTo(exitPoint.position);

        Destroy(currentCustomer.gameObject);
        currentCustomer = null;
    }

    public void OrderServed()
    {
        orderWait?.SetResult(true);
    }

    public IEnumerator StartDay()
    {
        foreach (CustomerSO customer in customers)
        {
            yield return SpawnCustomer(customer);
        }

        Debug.Log("Day complete");

        gameObject.SetActive(DayFinish);
    }

    IEnumerator SpawnCustomer(CustomerSO data)
    {
        dialogueRunner.VariableStorage.SetValue("$correctDish", false);
        GameObject obj = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);

        currentCustomer = obj.GetComponent<CustomerBehaviour>();
        currentCustomer.Initialize(data);

        yield return currentCustomer.MoveTo(counterPoint.position);

        currentOrder = currentCustomer.GetOrder();

        dialogueRunner.StartDialogue(data.yarnNode);

        while (currentCustomer != null)
            yield return null;

        while (dialogueRunner.IsDialogueRunning)
            yield return null;
    }
}
