using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private float movementSpeed = 20f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 directionBullet = new Vector3(0, 0, 1);
        transform.position += directionBullet * movementSpeed * Time.deltaTime;
    }
}
