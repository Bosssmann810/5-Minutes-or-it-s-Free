using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public bool m_facingLeft = false;
    public player_script player;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOrientation();
    }

    public void CheckOrientation()
    {
        if (player.faceingDerection >= 0)
        {
            m_facingLeft = false;
        }
        else if(player.faceingDerection < 0)
        {
            m_facingLeft=true;
        }
        spriteRenderer.flipX = m_facingLeft;
    }
}
