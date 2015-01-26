using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

	public GameObject interactionObject;
	public Items itemToPlace;
	// Use this for initialization
	void Start () {
	
	}

	private bool itemPlaced = false;
	private Items item = Items.None;

	// Update is called once per frame
	void Update () {
		if (itemPlaced)
		{
			var script = interactionObject.GetComponent<InteractiveController>();
			if (script.givesItem == item)
			{
				script.MakeItemAvailable();
			}
			else
			{
				script.RemoveItem();
			}
		}
	}

	public void PlaceItem(Items item)
	{
		itemPlaced = true;
		this.item = item;
	}

	public void TakeItem(Items item)
	{
		itemPlaced = false;
		this.item = item;
		
	}
}
