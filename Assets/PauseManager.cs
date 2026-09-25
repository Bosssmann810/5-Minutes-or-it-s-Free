using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseManager : MonoBehaviour
{
    public GameObject startGate;

    public GameObject timerObject;

    public GameObject spriteObject;

    private Animator spriteAnimator;

    private TimerScript timer;

    private StartGate gate;

    private player_script player;

    private PlayerInput input;

    private Rigidbody2D rb;

    public GameObject PauseUI;

    public GameObject PlayerObject;

    public GameObject heaterMeter;

    private HeatMeter meter;

    void start()
    {
        
        

        PauseUI.active = false;
    }

    void Awake()
    {
        spriteAnimator = spriteObject.GetComponent<Animator>();
        gate = startGate.GetComponent<StartGate>();
        timer = timerObject.GetComponent<TimerScript>();
        player = PlayerObject.GetComponent<player_script>();
        input = PlayerObject.GetComponent<PlayerInput>();
        rb = PlayerObject.GetComponent<Rigidbody2D>();
        meter = heaterMeter.GetComponent<HeatMeter>();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        if(gate.startGame == true)
        {
            timer.StartTimer();
        }

        meter.enabled = true;
        rb.WakeUp();
        PauseUI.active = false;
        player.enabled = true;
        input.enabled = true;
        spriteAnimator.enabled = true;

    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(player.enabled == true)
            {
                meter.enabled = false;
                PauseUI.active = true;
                player.enabled = false;
                input.enabled = false;
                spriteAnimator.enabled = false;
                rb.Sleep();
                timer.StopTimer();
            }
            else
            {
                meter.enabled = true;
                rb.WakeUp();
                PauseUI.active = false;
                player.enabled = true;
                input.enabled = true;
                spriteAnimator.enabled = true;
                if (gate.startGame == true)
                {
                    timer.StartTimer();
                }
            }
            
        }
    }

    public void DisableGame()
    {
        meter.enabled = false;
        player.enabled = false;
        input.enabled = false;
        spriteAnimator.enabled = false;
    }
}
