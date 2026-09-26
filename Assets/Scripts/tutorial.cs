using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class tutorial : MonoBehaviour
{
    

    public GameObject spriteObject;

    public GameObject controls;

    private Animator spriteAnimator;

    private player_script player;

    private PlayerInput input;

    private Rigidbody2D rb;

    public GameObject PlayerObject;

    public GameObject heaterMeter;

    private HeatMeter meter;

    void Awake()
    {
        spriteAnimator = spriteObject.GetComponent<Animator>();
        player = PlayerObject.GetComponent<player_script>();
        input = PlayerObject.GetComponent<PlayerInput>();
        rb = PlayerObject.GetComponent<Rigidbody2D>();
        meter = heaterMeter.GetComponent<HeatMeter>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meter.enabled = false;
        player.enabled = false;
        input.enabled = false;
        spriteAnimator.enabled = false;
        rb.Sleep();
        
    }

    public void OnContinue()
    {
        meter.enabled = true;
        rb.WakeUp();
        player.enabled = true;
        input.enabled = true;
        spriteAnimator.enabled = true;
        Destroy(gameObject);
        controls.SetActive(true);
    }
}
