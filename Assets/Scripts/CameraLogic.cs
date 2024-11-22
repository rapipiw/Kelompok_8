using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        Debug.Log(player.name);
    }

    
    void Update()
    {
        //Debug.Log(player.transform.position);
        if(player != null)
        {
            transform.position = player.transform.position;
        }
    }
}
