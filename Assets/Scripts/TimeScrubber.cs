using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScrubber : MonoBehaviour {

	public Slider slider;
	public float animationTime;
	public string animationName;
	private bool paused = false;

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

		

		if (Input.GetKeyDown(KeyCode.P)) 
		{
			PauseAnimation(animationName);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			ContinueAnimation(animationName);
		}

		GotoPositionInAnimation(animationName, animationTime * (1 - slider.value));
		UpdateSliderPosition ();
	}

	void PauseAnimation(string name)
	{
		((AnimationState)this.animation[name]).speed = 0f;
		paused = true;
	}

	void ContinueAnimation(string name)
	{
		((AnimationState)this.animation[name]).speed = 1f;
		paused = false;
	}

	void GotoPositionInAnimation(string name, float position)
	{
		if (paused) 
		{
			((AnimationState)this.animation [name]).time = position;
		}
	}

	void UpdateSliderPosition()
	{
		if (!paused) 
		{
			var currentTime = ((AnimationState)this.animation [animationName]).time;
			slider.value = 1 - (currentTime / animationTime);
		}

	}
}
