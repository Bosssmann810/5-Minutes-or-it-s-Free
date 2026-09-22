using JetBrains.Annotations;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TimerScript m_timer;
    private float m_timeRemaining;
    public float m_totalDamage = 0;

    public float m_totalScore;
    public GameObject m_gameOverUI;
    public GameObject m_gameWinUI;
    public TextMeshProUGUI m_scoreText;
    public TextMeshProUGUI m_timeRemainingText;
    public TextMeshProUGUI m_totalDamageText;
    private void Start()
    {
        m_totalDamage = 1;
        m_totalScore = 0;
        m_timeRemaining = 0;
        m_gameWinUI.SetActive(false);
        m_gameOverUI.SetActive(false);
    }
    public void GameOver()
    {
        m_gameOverUI.SetActive(true);
    }

    public void GameWon()
    {
        m_gameWinUI.SetActive(true);
        m_timeRemaining = m_timer.m_timer; 
        m_totalScore  = m_timeRemaining * 100 / m_totalDamage;
        m_timeRemainingText.text = $"Time Remaining: {Mathf.FloorToInt(m_timeRemaining / 60)} minutes and {Mathf.FloorToInt(m_timeRemaining % 60)} seconds";
        m_totalDamageText.text = $"Hits taken: {m_totalDamage -1}";
        m_scoreText.text = $"Final Score: {m_totalScore}";
    }
    public void DamageTaken()
    {
        m_totalDamage++;
    }

}
