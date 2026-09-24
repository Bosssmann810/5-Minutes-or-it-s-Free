using NUnit.Framework.Internal;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_script : MonoBehaviour
{
    public float topSpeed;
    private float normalSpeed = 10f;
    public float faceingDerection;
    public Vector2 movement;
    private float ThrusterSpeed = 20f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public float rayLength = 0.6f;
    public GameObject boostParticle;
    public LayerMask groundLayer;
    public bool isBurnedOut = false;
    public bool holdingThrusterButton = false;
    public bool iFramesActive = false;

    public ParticleSystem boostParticles;

    public float jumpForce = 400f;

    public GameManager m_gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        topSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
        //DO NOT CHANGE THIS UNLESS MASON SAYS TO
        if(faceingDerection >= 0)
        {
            boostParticle.transform.localPosition = new Vector3(-0.01000023f, 0.23f, 0);
            boostParticle.transform.rotation = new Quaternion(0,0, -260,30);
            
        }
        if(faceingDerection < 0)
        {
            boostParticle.transform.localPosition = new Vector3(0.5000023f, 0.23f, 0);
            boostParticle.transform.localRotation = new Quaternion(0,0,-60,100);
        }
       
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2( rb.linearVelocity.x + movement.x/5f, rb.linearVelocity.y);
        if (rb.linearVelocity.x > topSpeed)
        {
            //rb.linearVelocityX = topSpeed;
            rb.linearVelocityX -= topSpeed * Time.deltaTime * 2;
        }
        if (rb.linearVelocity.x < -topSpeed)
        {
            //rb.linearVelocityX = -topSpeed;
            rb.linearVelocityX += topSpeed * Time.deltaTime * 2;
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
            topSpeed = ThrusterSpeed;
            boostParticles.Play();
            if(faceingDerection != 0)
            {
                rb.AddForce(Vector2.right * faceingDerection * 500f);
            }
            else
            {
                rb.AddForce(Vector2.right  * 500f);
            }

            
        }
        if (context.performed)
        {
            holdingThrusterButton = true;
        }
        if (context.canceled)
        {

            boostParticles.Stop();
            

            topSpeed = normalSpeed;
            holdingThrusterButton = false;
        }
    }

    public void CancelThruster()
    {
        boostParticles.Stop();
        topSpeed = normalSpeed;
        
    }
    public void RestartThrusters()
    {
        Debug.Log("e");
        topSpeed = ThrusterSpeed;
        boostParticles.Play();
        if (faceingDerection != 0)
        {
            rb.AddForce(Vector2.right * faceingDerection * 1000f);
        }
        else
        {
            rb.AddForce(Vector2.right * 1000f);
        }
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            
            if (IsGrounded())
            {
                
                Debug.Log(context.action);
                rb.AddForce(Vector2.up * jumpForce);

            }
            
        }
        
        
    }

    bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
        return Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        

        
    }

    
    public void OnHit()
    {
        
        if (iFramesActive == false)
        {
            
            StartCoroutine(InvicibilityFrames());
        }
    }

    public IEnumerator InvicibilityFrames()
    {
        iFramesActive = true;
        Debug.Log("hit");
        rb.linearVelocityX = 0f;
        rb.AddForce(Vector2.up * 700f);
        m_gameManager.DamageTaken();
        yield return new WaitForSeconds(2);
        iFramesActive = false;
        Debug.Log("no more I frames");
        StopCoroutine(InvicibilityFrames());
    }

    
}
