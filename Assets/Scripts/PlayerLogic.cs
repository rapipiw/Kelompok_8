using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.DualShock.LowLevel;

public class PlayerLogic : MonoBehaviour
{
    private float movementSpeed = 8f;
    private float maxDistance = 4.5f;

    public GameObject directionBullet;
    void Start()
    {
        
    }

    
    void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        //Vector3 movementDirection = new Vector3(0, 0, inputHorizontal);
        Vector3 movementDirection = new Vector3(); //movement Direction => 0,0,0
        movementDirection.x = inputHorizontal;
        movementDirection.z = inputVertical;
        //Debug.Log(movementDirection);
        
        //Bentuk Singkat
        //transform.position += movementDirection * movementSpeed * Time.deltaTime;
        //Memasukkan nilai perubahan agar memastikan tidak melebihi batas maksimal
        Vector3 directionOutput = transform.position + (movementDirection * movementSpeed * Time.deltaTime);
        directionOutput.x = Mathf.Clamp(directionOutput.x, -maxDistance, maxDistance);
        directionOutput.z = Mathf.Clamp(directionOutput.z, -3.3f, 50);
        transform.position = directionOutput;

        // while (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("Eksekusi Logika Nembak");
        //     //Pembuatan Peluru Baru dengan mereferensikan
        //     //1. Apa yang ingin dibuat
        //     //2. Posisi ketika dia dibuat
        //     //3. Rotasinya => Quaternion.identity mengindikasikan bahwa rotasi dia berada di nilai default
        //     GameObject NewBullet = Instantiate(directionBullet, transform.position, Quaternion.identity);
        //     Destroy(NewBullet, 5.5f);
        //     if (Input.GetMouseButtonUp(0)){
        //         break;
        //     }
        // }

        if (Input.GetMouseButtonDown(0)) { 
            StartCoroutine(ShootBullets()); 
        } 

        if (Input.GetMouseButtonUp(0)) { 
            StopCoroutine(ShootBullets());
        } 
    } 
    
    IEnumerator ShootBullets() { 
        while (Input.GetMouseButton(0)) { 
            Debug.Log("Eksekusi Logika Nembak"); 
            GameObject NewBullet = Instantiate(directionBullet, transform.position, Quaternion.identity); 
            Destroy(NewBullet, 5.5f); 
            yield return new WaitForSeconds(0.5f); 
        }
    }
}
