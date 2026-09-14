using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_timerText;
    public bool m_isActive;
    public float m_timer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isActive)
        {
            m_timer -= Time.deltaTime;
        }
        if (m_timer < 0)
        {
            OutOfTime();
        }
        UpdateTimerText();
    }
    public void StartTimer()
    {
        m_isActive = true;
    }
    public void StopTimer()
    {
        m_isActive = false;
    }
    public void ResetTimer()
    {
        m_timer = 300;
    }

    public void OutOfTime()
    {
        Debug.Log("Out of time");
        m_isActive = false;
        //put game over function here
    }
    public void UpdateTimerText()
    {
        int m_minutes = Mathf.FloorToInt(m_timer / 60);
        int m_seconds = Mathf.FloorToInt(m_timer % 60);
        m_timerText.text = string.Format("{0}:{1:00}", m_minutes, m_seconds);
    }
}
