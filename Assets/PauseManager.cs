using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseManager : MonoBehaviour
{
    public TimerScript timerObject;

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
        timerObject.StartTimer();
        player.enabled = true;
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
                rb.Sleep();
                timerObject.StopTimer();
            }
            else
            {
                meter.enabled = true;
                rb.WakeUp();
                PauseUI.active = false;
                player.enabled = true;
                input.enabled = true;
                timerObject.StartTimer();
            }
            
        }
    }
}
