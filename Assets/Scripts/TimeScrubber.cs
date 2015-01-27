using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScrubber : MonoBehaviour {

	public Slider slider;
	public float animationTime;
	public string[] animationNames;
	public KeyCode pauseToggleButton;

	public string tagName;
	public int layerNumber;

	private bool paused = false;
	public bool started = false;

	void Start () 
	{
		slider.gameObject.SetActive(false);	
		this.PauseAnimation();
		slider.gameObject.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	private void ScrubTimeFor(string tag, int layer)
	{
		var gameObjects = GameObject.FindGameObjectsWithTag(tag);
			
		foreach(var item in gameObjects)
		{
			var animator = item.GetComponent<Animator>();
			
			if (animator.runtimeAnimatorController == null)
				continue;


			foreach(var name in animationNames)
			{
				var current = animator.GetCurrentAnimatorStateInfo(layer);
				if (current.IsName(name))
				{
					animator.CrossFade(name, 0f, 0, slider.value);
				}
			}

			//RuntimeAnimatorController ac = animator.runtimeAnimatorController as RuntimeAnimatorController;

			//var bob = "test";
			/**var stateCount = ac.GetLayer(layer).stateMachine.stateCount;
			
			for(int i = 0; i < stateCount; i++)
			{
				var name = ac.GetLayer(layer).stateMachine.GetState(i).name;
				var current = animator.GetCurrentAnimatorStateInfo(layer);
				if (current.IsName(name))
				{

				}
			}**/
		}
	}

	void FixedUpdate () 
	{
		if (!started)
			return;

		if (Input.GetKeyDown(pauseToggleButton)) 
		{
			if (paused)
			{
				ContinueAnimation();
			}
			else
			{
				PauseAnimation();
			}
		}

		GotoPositionInAnimation();
		UpdateSliderPosition ();
	}

	void PauseAnimation()
	{
		var gameObjects = GameObject.FindGameObjectsWithTag(tagName);

		foreach(var item in gameObjects)
		{
			var animator = item.GetComponent<Animator>();
			animator.speed = 0f;
		}

		paused = true;
		slider.gameObject.SetActive(paused);
		var playerController = Camera.main.GetComponent<PlayerController>();
		playerController.Pause();
	}

	public void StartGame()
	{
		started = true;
		slider.value = 0f;
		GotoPositionInAnimation();
		ContinueAnimation();
	}

	public void StopGame()
	{
		started = false;
		PauseAnimation();
		slider.gameObject.SetActive(false);
	}

	public void ContinueAnimation()
	{
		var gameObjects = GameObject.FindGameObjectsWithTag(tagName);
		
		foreach(var item in gameObjects)
		{
			var animator = item.GetComponent<Animator>();
			animator.speed = 1f;
		}

		paused = false;
		slider.gameObject.SetActive(paused);
		var playerController = Camera.main.GetComponent<PlayerController>();
		playerController.Continue();
	}

	void GotoPositionInAnimation()
	{
		if (paused) 
		{
			ScrubTimeFor(tagName, layerNumber);
		}
	}

	void UpdateSliderPosition()
	{
		if (!paused) 
		{
			var gameObjects = GameObject.FindGameObjectsWithTag(tagName);
			
			foreach(var item in gameObjects)
			{
				var animator = item.GetComponent<Animator>();
				var current = animator.GetCurrentAnimatorStateInfo(layerNumber);
				slider.value = current.normalizedTime;
			}
		}
	}
}
