using UnityEngine;

public class EndGate : MonoBehaviour
{
    [SerializeField] TimerScript m_timer;
    public GameManager m_gameManager;
    public PauseManager pause;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_timer.StopTimer();
            m_gameManager.GameWon();
            pause.DisableGame();
        }
    }
}

