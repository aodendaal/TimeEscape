﻿using UnityEngine;
using System.Collections;

public enum Items
{
	None,
	Gum,
	Mop,
	Keys

}

public class InteractiveController : MonoBehaviour 
{
	public KeyCode interactButton;
	private bool highlighting;
	public Items needsItem;
	public Items givesItem;
	public Sprite hasItemSprite;
	public Sprite missingItemSprite;
	public bool itemAvailable = false;
	public bool solvedInteraction = false;
	public GameObject objectToInteractWith = null;

	private bool placedItem = false;
	// Use this for initialization
	void Start () 
	{


	}

	public void MakeItemAvailable()
	{
		Debug.Log(givesItem.ToString() + " made available");
		itemAvailable = true;
	}

	bool SolvedKeys()
	{
		return DoesPlayerHaveItem(needsItem) && givesItem == Items.Keys;
	}

	bool SolvedGum()
	{
		return givesItem == Items.Gum;
	}

	bool SolvedMop()
	{
		return givesItem == Items.Mop;
	}

	// Update is called once per frame
	void Update () 
	{
		if (objectToInteractWith != null && objectToInteractWith.activeSelf)
		{
			itemAvailable = true;
		}
		else
		{
			itemAvailable = false;
		}

		if (Input.GetKeyUp(interactButton) && highlighting)
		{
			if (givesItem != Items.None && itemAvailable && (SolvedKeys() || SolvedGum() || SolvedMop()))
			{			
				GivePlayerItem();
				//solvedInteraction = true;
			}

 			if (!placedItem && DoesPlayerHaveItem(needsItem))
			{
				placedItem = true;
				solvedInteraction = true;
				var gameobject = this;

				var gum = GameObject.FindGameObjectWithTag("Gum");
				var gumController = gum.GetComponent<GumController>();
				if (gumController != null)
				{
					gumController.ShowGum();
					Debug.Log("Show Gum!");

				}
				else
				{
					Debug.Log("Null");

				}


			}
		}
	}

	public bool DoesPlayerHaveItem(Items needsItem)
	{
		var playerController = Camera.main.gameObject.GetComponentInChildren<PlayerController>();
		return playerController.HasItem(needsItem);
	}

	public void GivePlayerItem()
	{
		var playerController = Camera.main.gameObject.GetComponentInChildren<PlayerController>();
		playerController.GivesItem(givesItem);
		var components = objectToInteractWith.GetComponentsInChildren<MeshRenderer>();
		foreach(var item in components)
		{
			item.enabled = false;
		}
		givesItem = Items.None;
	}

    public void Highlight()
	{
		highlighting = true;
		UpdateHighlight(highlighting);

	}

	public void DontHighlight()
	{
		highlighting = false;
		UpdateHighlight(highlighting);
	}

	private void UpdateHighlight(bool highlighting)
	{

		var icon = this.gameObject.GetComponentInChildren<SpriteRenderer>();

		if (solvedInteraction)
		{
			icon.sprite = missingItemSprite;
		}
		else if (needsItem == Items.None && givesItem != Items.None && itemAvailable)
		{
			icon.sprite = hasItemSprite;
		}
		else if (needsItem == Items.None && givesItem == Items.None)
		{
			icon.sprite = missingItemSprite;
		}
		else
		{
			if (DoesPlayerHaveItem(needsItem))
			{
				icon.sprite = hasItemSprite;
			}
			else
			{
				icon.sprite = missingItemSprite;
			}
		}

		var anim = this.gameObject.GetComponentsInChildren<Animator>()[0];
		anim.SetBool("Interact", highlighting);
	}

	public void RemoveItem()
	{
		itemAvailable = false;
	}
}
