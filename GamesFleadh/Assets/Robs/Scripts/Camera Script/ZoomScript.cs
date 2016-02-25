
using UnityEngine;
using System.Collections;


public class ZoomScript : MonoBehaviour
{
    float minFov = 15f;
    float maxFov = 140f;
    float sensitivity = 50f;

    void Update()
    {
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}