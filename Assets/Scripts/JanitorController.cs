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

	public void StartAnimation()
	{
		Debug.Log("Drop Mop you basterd!");
		var components = this.gameObject.GetComponentsInChildren<Animator>();

		foreach(var animator in components)
		{
			animator.SetBool("DropMop", true);
		}
	}

	public void DropMop()
	{
		var mopController = this.gameObject.GetComponentInChildren<MopController>();
		
		mopController.MopInHand.SetActive(false);
		mopController.MopOnFloor.SetActive(true);
	}

	public void DoneCleaning()
	{
		Debug.Log("Pick up Mop!");
		var components = this.gameObject.GetComponentsInChildren<Animator>();
		
		foreach(var animator in components)
		{
			animator.SetBool("DropMop", false);
		}
	}
}
