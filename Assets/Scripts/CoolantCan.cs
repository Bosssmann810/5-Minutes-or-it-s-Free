using UnityEngine;

public class CoolantCan : MonoBehaviour
{
    public HeatMeter m_playerHeat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_playerHeat.m_totalHeat = 0;
            this.gameObject.SetActive(false);
        }
    }
}
