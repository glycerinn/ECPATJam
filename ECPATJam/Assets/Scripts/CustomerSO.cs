using UnityEngine;

[CreateAssetMenu(fileName = "New Customer", menuName = "Customer")]
public class CustomerSO : ScriptableObject
{
    public string customerName;
    public Sprite sprite;

    public RecipeSO order;
    public int orderAmount = 1;

    public string yarnNode;
}