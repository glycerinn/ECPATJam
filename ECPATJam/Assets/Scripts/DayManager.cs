using UnityEngine;

public class DayManager : MonoBehaviour
{
    public CustomerManager customerManager;

    void Start()
    {
        StartCoroutine(customerManager.StartDay());
    }
}