using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	bool firstRun = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetKey(KeyCode.Space)&& firstRun)
		{
			var timeScrubberScript = Camera.main.GetComponent<TimeScrubber>();
			timeScrubberScript.StartGame();
			firstRun = false;
			var menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Image>();
			menu.enabled = false;

		}

		if (Input.GetKey(KeyCode.Escape))
		{
			var timeScrubberScript = Camera.main.GetComponent<TimeScrubber>();
			firstRun = true;

			timeScrubberScript.StopGame();
			var menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Image>();

			menu.enabled = true;

		}

		var winCondition = GameObject.FindGameObjectWithTag("WinCondition").GetComponent<InteractiveController>();
		if (winCondition.solvedInteraction)
		{
			GameOver();
		}
	}

	void GameOver()
	{
		var win = GameObject.FindGameObjectWithTag("Win").GetComponent<Image>();
		var menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Image>();
		menu.enabled = false;
		win.enabled = true;

	}
}
