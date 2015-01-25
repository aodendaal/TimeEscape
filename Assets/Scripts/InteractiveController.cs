using UnityEngine;
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

	public bool solvedInteraction = false;

	private bool placedItem = false;
	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log("Highlighting : " + this.name + " " + highlighting);

		if (Input.GetKeyUp(interactButton) && highlighting)
		{
			if (givesItem != Items.None)
			{			
				GivePlayerItem();
			}

			if (placedItem && DoesPlayerHaveItem(needsItem))
			{
				solvedInteraction = true;
				//var anim = this.gameObject.GetComponentsInChildren<Animator>()[0];
				//anim.SetBool("InteractSolved", solvedInteraction);
			}
			else if (!placedItem && DoesPlayerHaveItem(needsItem))
			{
				placedItem = true;
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
		else if (needsItem == Items.None && givesItem != Items.None)
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
}
