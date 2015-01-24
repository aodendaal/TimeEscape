using UnityEngine;
using System.Collections;

public class TimeScrubber : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void FixedUpdate () 
	{
		var animator = this.GetComponent<Animator> ();



		if (Input.GetKeyDown(KeyCode.P)) 
		{
			((AnimationState)this.animation["Walk"]).speed = 0f;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			((AnimationState)this.animation["Walk"]).speed = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			((AnimationState)this.animation["Walk"]).enabled = true;
			((AnimationState)this.animation["Walk"]).weight = 1f;
			((AnimationState)this.animation["Walk"]).time = 10f;
			//foreach (AnimationState state in ) 
			//{
				//state.enabled = true;
				//state.weight = 1f;
				//state.speed = 0;
				//state.time = 10f;
			//}
		}
	}
}
