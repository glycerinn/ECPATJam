using UnityEngine;

[CreateAssetMenu(fileName = "New Customer", menuName = "Customer")]
public class CustomerSO : ScriptableObject
{
    public string customerName;
    public Sprite sprite;
    public RecipeSO order;
    public string yarnNode;
}
