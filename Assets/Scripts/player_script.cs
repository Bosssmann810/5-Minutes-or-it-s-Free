using UnityEngine;
using UnityEngine.InputSystem;

public class player_script : MonoBehaviour
{
    public Vector2 movement;
    private float ThrusterSpeed = 10f;
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * movementSpeed;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement =  new Vector2(context.ReadValue<Vector2>().x, 0f);
        
        
    }
    public void OnThruster(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movementSpeed = ThrusterSpeed;
        }
        if (context.canceled)
        {
            movementSpeed = 2f;
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            rb.AddForce(Vector2.up * 10000f);
        }
        
        Debug.Log(context.action);
    }
}
