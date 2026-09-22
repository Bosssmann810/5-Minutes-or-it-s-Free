using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_script : MonoBehaviour
{
    private float faceingDerection;
    public Vector2 movement;
    private float ThrusterSpeed = 10f;
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public float rayLength = 0.6f;
    public LayerMask groundLayer;
    public bool isBurnedOut = false;
    public bool holdingThrusterButton = false;
    public bool iFramesActive = false;

    public float jumpForce = 10;
    public bool test = false;

    public GameManager m_gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2( rb.linearVelocity.x + movement.x /5f , rb.linearVelocity.y);
        // gravity here might need to fix the 1000 or use old gravity 
        //rb.AddForce(Physics.gravity * Time.deltaTime*1000 * rb.mass);

        if (test)
        {
            rb.AddForce(Vector2.up *jumpForce * Time.deltaTime* 6f, ForceMode2D.Impulse);
            Invoke(nameof(Wait), 0.25f);
            
            
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement =  new Vector2(context.ReadValue<Vector2>().x, 0f);
        if (movement.x != 0)
        {
            faceingDerection = movement.x;
        }
        



    }
    public void OnThruster(InputAction.CallbackContext context)
    {
        if (context.performed && isBurnedOut == false)
        {
            Debug.Log("e");
            movementSpeed = ThrusterSpeed;
            if(faceingDerection != 0)
            {
                rb.AddForce(Vector2.right * faceingDerection * 1000f);
            }
            else
            {
                rb.AddForce(Vector2.right  * 1000f);
            }

            
        }
        if (context.performed)
        {
            holdingThrusterButton = true;
        }
        if (context.canceled)
        {
            movementSpeed = 2f;
            holdingThrusterButton = false;
        }
    }

    public void CancelThruster()
    {
        movementSpeed = 2f;
    }
    public void RestartThrusters()
    {
        Debug.Log("e");
        movementSpeed = ThrusterSpeed;
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            
            if (IsGrounded())
            {
                test = true;
                Debug.Log(context.action);
                
                
            }
            
        }
        
        
    }

    bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
        return Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        

        
    }

    void Wait()
    {
        test = false;
    }

    public void OnHit()
    {
        if(iFramesActive == false)
        {
            StartCoroutine(InvicibilityFrames());
        }
    }

    public IEnumerator InvicibilityFrames()
    {
        iFramesActive = true;
        Debug.Log("hit");
        rb.linearVelocityX = 0f;
        rb.AddForce(Vector2.up * 100f);
        m_gameManager.DamageTaken();
        yield return new WaitForSeconds(2);
        iFramesActive = false;
        Debug.Log("no more I frames");
        StopCoroutine(InvicibilityFrames());
    }
}
