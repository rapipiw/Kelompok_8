using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float movementSpeed = 6f;
    public GameManagerLogic gameManagerLogic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManagerLogic.GameOver)
        {
            Vector3 direction = new Vector3(-1, 0, 0);
            transform.position += direction * movementSpeed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.CompareTag("directionBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            gameManagerLogic.GameOver = true;
            gameManagerLogic.ui.gameObject.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
}
