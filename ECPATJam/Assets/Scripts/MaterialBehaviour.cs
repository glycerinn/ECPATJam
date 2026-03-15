using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaterialBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] MaterialSO materialSO;
    [SerializeField] bool HasBeenClicked;
    private Vector3 StartPos;
    bool isDragging = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {   
        spriteRenderer.sprite = materialSO.MaterialSprite;
        StartPos = materialSO.MaterialStartPos;
        HasBeenClicked = false;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            transform.position = GetMousePos();

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                rb.gravityScale = 1;
            }
        }

        if(transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }

    public void StartDragging()
    {
        isDragging = true;
        HasBeenClicked = true;
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void OnMouseDrag()
    {
        HasBeenClicked = true;
        rb.MovePosition(GetMousePos());
    }

    public MaterialSO GetMaterial()
    {
        return materialSO;
    }

        public void SetMaterial(MaterialSO newMaterial)
    {
        materialSO = newMaterial;
        spriteRenderer.sprite = materialSO.MaterialSprite;
    }
}
