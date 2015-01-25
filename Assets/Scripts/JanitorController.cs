using UnityEngine;
using System.Collections;

public class JanitorController : MonoBehaviour 
{
	public GameObject floor;
	public GameObject otherJanitor;
	public bool solvedState = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		var script = floor.GetComponent<InteractiveController>();

		if (script.solvedInteraction == solvedState)
		{
			otherJanitor.SetActive(false);
			this.gameObject.SetActive(true);
		}
		else
		{
			otherJanitor.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
