using UnityEngine;

public class DamagePit : MonoBehaviour
{
    private player_script m_player;
    public Transform m_respawnPoint;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("a");
            m_player = collision.gameObject.GetComponent<player_script>();
            m_player.OnHit();
            collision.gameObject.transform.position = m_respawnPoint.position;
        }

    }
}
