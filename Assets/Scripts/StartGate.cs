using UnityEngine;

public class StartGate : MonoBehaviour
{
    
    public GameObject TutorialUI;
    [SerializeField] TimerScript m_timer;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TutorialUI.SetActive(false);
            m_timer.StartTimer();
        }
    }
}
