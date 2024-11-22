using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLogic : MonoBehaviour
{
    public EnemyLogic enemyPrefab;
    
    public float currentInterval = 0f;
    public float Interval = 2f;
    public float maxDistance = 8f;
    
    public bool GameOver = false;

    public Canvas ui;
    //ui.gameobject.setActive(true);
    void Start()
    {
        ui.gameObject.SetActive(false);
    }
    void Update()
    {
        if (!GameOver)
        {
            currentInterval = currentInterval + Time.deltaTime;
            if (currentInterval > Interval)
            {
                currentInterval = 0;
                Vector3 spawnPosition = transform.position;
                spawnPosition.z = Random.Range(-maxDistance, maxDistance);
                EnemyLogic NewEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                NewEnemy.gameManagerLogic = this;
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
