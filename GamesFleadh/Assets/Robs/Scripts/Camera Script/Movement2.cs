using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour
{
    float speed = 1000;
    GameObject cam;
    float maxX, minX, maxZ, minZ;
    
    void Start()
    {
        cam = GameObject.Find("MainCamera");

        maxX = 10;
        minX = -10;
        maxZ = 10;
        minZ = 10;
    }

    
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.D) && (cam.transform.position.x >= -10) && (cam.transform.position.x <= 10))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            movement.x++;
            Debug.Log("D");
        }
        if (Input.GetKey(KeyCode.A) && (cam.transform.position.x >= -10) && (cam.transform.position.x <= 10))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            movement.x--;
        }
        if (Input.GetKey(KeyCode.S) && (cam.transform.position.z >= -10) && (cam.transform.position.z <= 10))
        {
            //transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            movement.y--;
        }
        if (Input.GetKey(KeyCode.W) && (cam.transform.position.z >= -10) && (cam.transform.position.z <= 10))
        {
            //transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            movement.y++;
        }

        Mathf.Clamp(transform.position.x, minX, maxX);
        Mathf.Clamp(transform.position.z, minZ, maxZ);



        /*if(cam.transform.position.x < minX)
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.Self);
            movement.x = maxX +  1;
            Debug.Log("working");
        }
        if (transform.position.x > maxX)
        {
            
            transform.Translate(movement * speed * Time.deltaTime, Space.Self);
            movement.x = maxX - 1;
            Debug.Log("working too");
            
            movement.x = -1;
            transform.Translate(movement * speed * Time.deltaTime, Space.Self);
            Debug.Log("working too");
            
        }

        //transform.Translate(movement * speed * Time.deltaTime, Space.Self);
        */
    }
}
