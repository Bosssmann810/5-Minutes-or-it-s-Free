using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class player_animations : MonoBehaviour
{
    public player_script player;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 moveInput;
    private Vector2 jump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(horizontal, vertical).normalized;
        jump = new Vector2(0, vertical).normalized;
        animator.SetBool("IsMoving", moveInput != Vector2.zero);

        animator.SetBool("IsJumping", jump != Vector2.zero);
    }
}
