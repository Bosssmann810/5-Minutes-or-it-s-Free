using UnityEngine;

public class EndGate : MonoBehaviour
{
    public class StartGate : MonoBehaviour
    {
        [SerializeField] TimerScript m_timer;


        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                m_timer.StopTimer();
            }
        }
    }
}
