using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	public float Angle;
	public float Period;
	
	private float _Time;
	
	void Update () 
	{
		_Time = _Time + Time.deltaTime;
		float phase = Mathf.Sin(_Time / Period);
		transform.localRotation = Quaternion.Euler( new Vector3(0, phase * Angle, 0));
	}
}