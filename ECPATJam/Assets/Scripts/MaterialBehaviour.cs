using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaterialBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] MaterialSO materialSO;
    [SerializeField] bool HasBeenClicked;
    private Vector3 StartPos;

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
        
        if(HasBeenClicked == false)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            transform.eulerAngles = Vector3.zero;
        }
        else if(HasBeenClicked == true)
        {
            rb.gravityScale = 1;
        }

        if(transform.position.y <= -6)
        {
            transform.position = StartPos;
            HasBeenClicked = false;
        }
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
        transform.position = GetMousePos();
    }

    public MaterialSO GetMaterial()
    {
        return materialSO;
    }
}
