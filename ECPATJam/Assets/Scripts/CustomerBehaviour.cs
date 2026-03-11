using UnityEngine;
using System.Collections;

public class CustomerBehaviour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float moveSpeed = 3f;

    CustomerSO data;

    public void Initialize(CustomerSO customerData)
    {
        data = customerData;
        spriteRenderer.sprite = data.sprite;
    }

    public IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }
    }

    public RecipeSO GetOrder()
    {
        return data.order;
    }

    public string GetDialogueNode()
    {
        return data.yarnNode;
    }
}
