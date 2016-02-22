using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour 
{

    private Vector3 targetV;
    private WaypointInput input;
    public float RotationSpeed;
    private Quaternion _lookRotation;
    private Vector3 _direction;
    public Vector3 modTargetV;
    public float tempTurnSpeed;

    public float speed = 10.0F;
    public float trottle;

    void Start()
    {
        tempTurnSpeed = 0;
    }

    void Update()
    {
        updateVelocity();
        turnToWaypoint();
    }

    void updateVelocity()
    {
        Vector3 dir = Vector3.zero;
        dir.z = trottle;
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    }

    void turnToWaypoint()
    {
        trottle = 1;
        input = gameObject.GetComponent<WaypointInput>();
        if (targetV != new Vector3(0,0,0))
        {
            targetV = input.getWaypoint(this.transform.position);
            modTargetV = targetV;
            modTargetV.y = transform.position.y;
            targetV.y = 33.0f;

            //find the vector pointing from our position to the target
            _direction = (modTargetV - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
        }
        else 
        {
            trottle = 0;
        }
    }
}
