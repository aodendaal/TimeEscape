using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScrubber : MonoBehaviour {

	public Slider slider;
	public float animationTime;
	public string animationName;
	public KeyCode pauseToggleButton;
	private bool paused = false;

	// Use this for initialization
	void Start () 
	{
		slider.gameObject.SetActive(false);		
	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void FixedUpdate () 
	{
		if (Input.GetKeyDown(pauseToggleButton)) 
		{
			if (paused)
			{
				ContinueAnimation(animationName);
			}
			else
			{
				PauseAnimation(animationName);
			}
		}

		GotoPositionInAnimation(animationName, animationTime * (slider.value));
		UpdateSliderPosition ();
	}

	void PauseAnimation(string name)
	{
		slider.gameObject.SetActive(true);
		((AnimationState)this.animation[name]).speed = 0f;
		paused = true;

		var playerController = Camera.main.GetComponent<PlayerController>();
		playerController.Pause();
	}

	void ContinueAnimation(string name)
	{
		slider.gameObject.SetActive(false);
		((AnimationState)this.animation[name]).speed = 1f;
		paused = false;

		var playerController = Camera.main.GetComponent<PlayerController>();
		playerController.Continue();
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
			var currentTime = ((AnimationState)this.animation[animationName]).time;
			slider.value = (currentTime / animationTime);
		}

	}
}
