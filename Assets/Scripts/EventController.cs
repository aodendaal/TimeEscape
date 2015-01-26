using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

	public GameObject interactionObject;
	public Items itemToPlace;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PlaceItem(Items item)
	{
		var script = interactionObject.GetComponent<InteractiveController>();
		if (script.givesItem == item)
		{
			script.MakeItemAvailable();
		}

	}

	public void TakeItem(Items item)
	{
		var script = interactionObject.GetComponent<InteractiveController>();
		if (script.givesItem == item)
		{
			script.RemoveItem();
		}
		
	}
}
