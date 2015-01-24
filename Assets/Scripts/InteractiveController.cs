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

	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp(interactButton))
		{
			Debug.Log("Interact");
			var playerController = Camera.main.gameObject.GetComponentInChildren<PlayerController>();
			playerController.GivesItem(givesItem);
			givesItem = Items.None;
		}
	}

    public void Highlight()
	{
		var highlighting = true;
		UpdateHighlight(highlighting);

	}

	public void DontHighlight()
	{
		var highlighting = false;
		UpdateHighlight(highlighting);
	}

	private void UpdateHighlight(bool highlighting)
	{
		var playerController = Camera.main.gameObject.GetComponentInChildren<PlayerController>();
		var icon = this.gameObject.GetComponentInChildren<SpriteRenderer>();

		if (needsItem == Items.None && givesItem != Items.None)
		{
			icon.sprite = hasItemSprite;
		}
		else if (needsItem == Items.None && givesItem == Items.None)
		{
			icon.sprite = missingItemSprite;
		}
		else
		{
			if (playerController.HasItem(needsItem))
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
