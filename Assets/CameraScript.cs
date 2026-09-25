using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Transform cameraMin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= cameraMin.transform.position.y)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x +2f, cameraMin.transform.position.y + 2f, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(player.transform.position.x+ 2f, player.transform.position.y, gameObject.transform.position.z);
        }
        
         
        
    }
}
