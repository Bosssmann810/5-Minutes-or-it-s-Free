using UnityEngine;

public class StartGate : MonoBehaviour
{
    public bool startGame = false;
    public GameObject TutorialUI;
    [SerializeField] TimerScript m_timer;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startGame = true;
            TutorialUI.SetActive(false);
            m_timer.StartTimer();
        }
    }
}
