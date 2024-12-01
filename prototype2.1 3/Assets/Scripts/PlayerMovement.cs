using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 1f;

    private Player control;
    private Vector2 move;
    private Rigidbody2D rb;

    private void PlayerInput()
    {
        move = control.Move.Movement.ReadValue<Vector2>();
    }


    private void Move()
    {
        rb.MovePosition(rb.position + move * (speed * Time.fixedDeltaTime));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Awake()
    {
        control = new Player();
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        control.Enable();
    }
}
