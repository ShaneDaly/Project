using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour
{
    public float rotateSpeed;
    private Vector3 sunVec;

    // Update is called once per frame
    void Update()
    {
        sunVec = transform.parent.position;
        transform.RotateAround(sunVec, Vector3.down, rotateSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.red;
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        UnityEditor.Handles.DrawWireDisc(transform.parent.position, Vector3.up, distance);
    }
}
