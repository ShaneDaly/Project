using UnityEngine;
using System.Collections;

public class OnOff : MonoBehaviour {

	public enum State {On, Off};
	public State state;

	void On ()
	{
		gameObject.SetActive (true);
	}
	void Off ()
	{
		gameObject.SetActive (false);
	}

	void Update () {


		switch (state) 
		{
		case(State.On):
		{
			On ();
			break;
		}
		case(State.Off):
		{
			Off ();
			break;
		}

		}
		if (Input.GetKeyDown("space"))
		{
			if(state == State.On)
			{
				state = State.Off;
			}
			if(state == State.Off)
			{
				state = State.On;
			}
		}

	}
}
