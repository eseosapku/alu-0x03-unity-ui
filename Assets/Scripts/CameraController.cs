using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraLocation();
    }

    void CameraLocation()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        }
    }
}
