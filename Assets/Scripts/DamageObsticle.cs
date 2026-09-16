using UnityEngine;

public class DamageObsticle : MonoBehaviour
{
    private player_script m_player;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("a");
            m_player = collision.gameObject.GetComponent<player_script>();
            m_player.OnHit();
        }
        
    }
}
